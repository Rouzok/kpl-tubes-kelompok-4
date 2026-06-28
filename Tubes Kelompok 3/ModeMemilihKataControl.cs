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
            MuatDataSistem();

            if (CekValidasiKetersediaanData())
            {
                TampilkanSoalKeAntarmuka(_indeksSoalAktif);
            }

            btnSubmit.Click += BtnSubmit_Click;
        }

        private void MuatDataSistem()
        {
            // SECURE CODING / DEFENSIVE PROGRAMMING: 
            // Mencegah Path Traversal (Tricky/Invalid Paths) dengan membatasi eksekusi pada BaseDirectory yang aman.
            string pathAman = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NamaFileSoal);

            // DEFENSIVE PROGRAMMING: 
            if (!File.Exists(pathAman))
            {
                TampilkanPesanError($"Berkas sumber data '{NamaFileSoal}' tidak ditemukan.", ErrorJudulSistem);
                _tabelSoal = new List<DataSoal>();
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(pathAman);
                _tabelSoal = JsonSerializer.Deserialize<List<DataSoal>>(jsonString);
            }
            catch (JsonException)
            {
                // DEFENSIVE PROGRAMMING: 
                TampilkanPesanError(ErrorFormatJson, ErrorJudulData);
                _tabelSoal = new List<DataSoal>();
            }
        }

        private bool CekValidasiKetersediaanData()
        {
            return _tabelSoal != null && _tabelSoal.Count > 0;
        }

        private void TampilkanSoalKeAntarmuka(int indeks)
        {
            // PRECONDITION
            // Memastikan input indeks absolut berada dalam batas jangkauan array/list tabel.
            if (_tabelSoal == null || indeks < 0 || indeks >= _tabelSoal.Count)
            {
                throw new IndexOutOfRangeException($"Kontrak Dilanggar: Indeks soal {indeks} di luar jangkauan _tabelSoal.");
            }

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
            if (!ValidasiStatusIndeksSoal()) return;

            DataSoal soalAktif = _tabelSoal[_indeksSoalAktif];
            (int totalBenar, int totalSalah) = KalkulasiSkorJawaban(soalAktif);

            int jumlahJawabanBenarSeharusnya = soalAktif.OpsiKata.Values.Count(val => val);

            // DEFENSIVE PROGRAMMING 
            int skorAkhir = Math.Max(0, totalBenar - totalSalah);

            TampilkanHasilEvaluasi(totalBenar, totalSalah, jumlahJawabanBenarSeharusnya, skorAkhir);
        }

        private bool ValidasiStatusIndeksSoal()
        {
            // DEFENSIVE PROGRAMMING: 
            if (_tabelSoal == null || _indeksSoalAktif < 0 || _indeksSoalAktif >= _tabelSoal.Count)
            {
                TampilkanPesanError(ErrorDataTidakValid, ErrorJudulData);
                return false;
            }
            return true;
        }

        private (int benar, int salah) KalkulasiSkorJawaban(DataSoal soalAktif)
        {
            int hitungBenar = 0;
            int hitungSalah = 0;

            foreach (Control control in flpWordContainer.Controls)
            {
                if (control is Button btnWord)
                {
                    string kata = btnWord.Text;
                    bool statusTerpilih = btnWord.BackColor == Color.DeepSkyBlue;

                    // DEFENSIVE PROGRAMMING: 
                    if (soalAktif.OpsiKata.TryGetValue(kata, out bool statusValiditasTabel))
                    {
                        if (statusTerpilih)
                        {
                            if (statusValiditasTabel) hitungBenar++;
                            else hitungSalah++;
                        }
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
    }
}