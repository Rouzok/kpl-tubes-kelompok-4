using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeMemilihKataControl : UserControl, IGameMode
    {
        private const string NamaFileSoal = "DataSoal.json";
        private const string ErrorJudulSistem = "Kesalahan Sistem";
        private const string ErrorJudulData = "Kesalahan Data";
        private const string ErrorDataTidakValid = "Terjadi kesalahan sistem: Data soal tidak valid.";
        private const string ErrorFormatJson = "Terjadi kesalahan pada format data JSON.";

        private class DataSoal
        {
            public string JudulSoal { get; set; }
            public Dictionary<string, bool> OpsiKata { get; set; }
        }

        private List<DataSoal> _tabelSoal;
        private int _indeksSoalAktif = 0;

        public ModeMemilihKataControl()
        {
            InitializeComponent();
            MuatSoalDariDatabase();

            if (IsIndeksSoalValid(_indeksSoalAktif))
            {
                TampilkanSoalKeAntarmuka(_indeksSoalAktif);
            }

            btnSubmit.Click += BtnSubmit_Click;
        }

        private void MuatSoalDariDatabase()
        {
            int levelSaatIni = GameManager.Instance.CurrentLevel;
            var dataDb = DatabaseSingleton.GetInstance().GetSoalMemilihKata(levelSaatIni);

            if (dataDb != null){
                _tabelSoal = new List<DataSoal>();
                DataSoal soalBaru = new DataSoal
                {
                    JudulSoal = dataDb.JudulSoal,
                    OpsiKata = new Dictionary<string, bool>()
                };

                // Parsing opsi benar dengan delimiter koma
                string[] kataBenar = dataDb.OpsiBenar.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string k in kataBenar)
                {
                    soalBaru.OpsiKata[k.Trim()] = true;
                }

                // Parsing opsi salah dengan delimiter koma
                string[] kataSalah = dataDb.OpsiSalah.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string k in kataSalah)
                {
                    soalBaru.OpsiKata[k.Trim()] = false;
                }

                // Pengacakan (Shuffling) urutan elemen Dictionary menggunakan LINQ OrderBy Guid
                soalBaru.OpsiKata = soalBaru.OpsiKata
                    .OrderBy(x => Guid.NewGuid())
                    .ToDictionary(item => item.Key, item => item.Value);

                _tabelSoal.Add(soalBaru);
            }
            else{
                TampilkanPesanError($"Data soal untuk Level {levelSaatIni} tidak ditemukan di database.", ErrorJudulData);
                _tabelSoal = new List<DataSoal>();
            }
        }

        private bool IsIndeksSoalValid(int indeks)
        {
            if (_tabelSoal == null || indeks < 0 || indeks >= _tabelSoal.Count)
            {
                TampilkanPesanError(ErrorDataTidakValid, ErrorJudulData);
                return false;
            }
            return true;
        }

        private void TampilkanSoalKeAntarmuka(int indeks)
        {
            BersihkanPanelKata();

            DataSoal soal = _tabelSoal[indeks];
            lblTitle.Text = soal.JudulSoal;

            // INVARIANT
            // Mengevaluasi integritas objek. Objek soal wajib memiliki setidaknya satu opsi kata.
            if (soal.OpsiKata.Count == 0)
            {
                throw new InvalidOperationException("Kontrak Invarian Dilanggar: Data soal tidak memiliki opsi kata.");
            }

            RenderTombolOpsiKata(soal.OpsiKata);
        }

        // SRP : Pemisahan logika UI disposal
        private void BersihkanPanelKata()
        {
            // CLEAN CODE: Optimasi pelepasan memori agar menghindari kebocoran memori (Memory Leak).
            while (flpWordContainer.Controls.Count > 0)
            {
                flpWordContainer.Controls[0].Dispose();
            }
        }

        // SRP : Pemisahan logika perenderan komponen antarmuka
        private void RenderTombolOpsiKata(Dictionary<string, bool> opsiKata)
        {
            foreach (KeyValuePair<string, bool> item in opsiKata)
            {
                Button btnWord = new Button
                {
                    Text = item.Key,
                    Size = new Size(100, 40),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                btnWord.Click += WordButton_Click;
                flpWordContainer.Controls.Add(btnWord);
            }
        }

        private void WordButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                bool isSelected = clickedButton.BackColor == Color.DeepSkyBlue;

                clickedButton.BackColor = isSelected ? Color.White : Color.DeepSkyBlue;
                clickedButton.ForeColor = isSelected ? Color.Black : Color.White;
            }
        }

        public void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsIndeksSoalValid(_indeksSoalAktif)) return;

            DataSoal soalAktif = _tabelSoal[_indeksSoalAktif];
            (int totalBenar, int totalSalah) = KalkulasiSkorJawaban(soalAktif);

            int jumlahJawabanBenarSeharusnya = soalAktif.OpsiKata.Values.Count(val => val);
            int jumlahBenarTernormalisasi = Math.Max(0, totalBenar - totalSalah);

            int persentaseSkor = 0;
            if (jumlahJawabanBenarSeharusnya > 0)
            {
                persentaseSkor = (int)Math.Round((double)jumlahBenarTernormalisasi / jumlahJawabanBenarSeharusnya * 100);
            }

            persentaseSkor = Math.Min(100, persentaseSkor);

            int idPenggunaAktif = UserSession.Instance.CurrentUser.IdUser;
            int idLevelAktif = GameManager.Instance.CurrentLevel;

            DatabaseSingleton.GetInstance().SimpanSkorUser(idPenggunaAktif, idLevelAktif, persentaseSkor);

            TampilkanHasilEvaluasi(totalBenar, totalSalah, jumlahJawabanBenarSeharusnya, persentaseSkor);

             GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_MEMILIH_KATA;
        }

        private (int benar, int salah) KalkulasiSkorJawaban(DataSoal soalAktif)
        {
            int hitungBenar = 0;
            int hitungSalah = 0;

            foreach (Button btnWord in flpWordContainer.Controls.OfType<Button>()){
                string kata = btnWord.Text;
                bool statusTerpilih = btnWord.BackColor == Color.DeepSkyBlue;

                if (soalAktif.OpsiKata.TryGetValue(kata, out bool statusValiditasTabel)){
                    if (statusTerpilih){
                        if (statusValiditasTabel) hitungBenar++;
                        else hitungSalah++;
                    }
                }
            }

            return (hitungBenar, hitungSalah);
        }

        private void TampilkanPesanError(string pesan, string judul)
        {
            MessageBox.Show(pesan, judul, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TampilkanHasilEvaluasi(int totalBenar, int totalSalah, int jumlahTarget, int skorAkhir)
        {
            string pesanHasil = $"Evaluasi Penyelesaian:\n\n" +
                                $"- Kata benar yang ditemukan: {totalBenar} dari {jumlahTarget}\n" +
                                $"- Kesalahan pemilihan: {totalSalah}\n" +
                                $"- Total Skor: {skorAkhir}";

            MessageBox.Show(pesanHasil, "Hasil Penilaian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public UserControl GetControl()
        {
            return this;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_MEMILIH_KATA;
        }
    }
}