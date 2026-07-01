using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeMemilihKataControl : UserControl
    {
        private const string ErrorJudulData = "Kesalahan Data";
        private const string ErrorDataTidakValid = "Terjadi kesalahan sistem: Data soal tidak valid.";

        private readonly IScoreStrategy scoreStrategy;

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

            scoreStrategy = new MemilihKataScoreStrategy();

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

            if (dataDb != null)
            {
                _tabelSoal = new List<DataSoal>();

                DataSoal soalBaru = new DataSoal
                {
                    JudulSoal = dataDb.JudulSoal,
                    OpsiKata = new Dictionary<string, bool>()
                };

                foreach (string k in dataDb.OpsiBenar.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    soalBaru.OpsiKata[k.Trim()] = true;
                }

                foreach (string k in dataDb.OpsiSalah.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    soalBaru.OpsiKata[k.Trim()] = false;
                }

                soalBaru.OpsiKata = soalBaru.OpsiKata
                    .OrderBy(x => Guid.NewGuid())
                    .ToDictionary(x => x.Key, x => x.Value);

                _tabelSoal.Add(soalBaru);
            }
            else
            {
                MessageBox.Show(
                    $"Data soal untuk Level {levelSaatIni} tidak ditemukan.",
                    ErrorJudulData,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                _tabelSoal = new List<DataSoal>();
            }
        }

        private bool IsIndeksSoalValid(int indeks)
        {
            if (_tabelSoal == null || indeks < 0 || indeks >= _tabelSoal.Count)
            {
                MessageBox.Show(
                    ErrorDataTidakValid,
                    ErrorJudulData,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void TampilkanSoalKeAntarmuka(int indeks)
        {
            BersihkanPanelKata();

            DataSoal soal = _tabelSoal[indeks];

            lblTitle.Text = soal.JudulSoal;

            if (soal.OpsiKata.Count == 0)
            {
                throw new InvalidOperationException("Data soal kosong.");
            }

            RenderTombolOpsiKata(soal.OpsiKata);
        }

        private void BersihkanPanelKata()
        {
            while (flpWordContainer.Controls.Count > 0)
            {
                flpWordContainer.Controls[0].Dispose();
            }
        }

        private void RenderTombolOpsiKata(Dictionary<string, bool> opsiKata)
        {
            foreach (var item in opsiKata)
            {
                Button btn = new Button
                {
                    Text = item.Key,
                    Size = new Size(100, 40),
                    BackColor = Color.White,
                    ForeColor = Color.Black
                };

                btn.Click += WordButton_Click;

                flpWordContainer.Controls.Add(btn);
            }
        }

        private void WordButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            bool selected = btn.BackColor == Color.DeepSkyBlue;

            btn.BackColor = selected ? Color.White : Color.DeepSkyBlue;
            btn.ForeColor = selected ? Color.Black : Color.White;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsIndeksSoalValid(_indeksSoalAktif))
                return;

            DataSoal soal = _tabelSoal[_indeksSoalAktif];

            int score = HitungScore(soal);

            int jumlahBenar =
                soal.OpsiKata.Values.Count(v => v);

            int persentase = 0;

            if (jumlahBenar > 0)
            {
                persentase = (int)Math.Round(
                    (double)score / jumlahBenar * 100);
            }

            persentase = Math.Min(100, persentase);

            DatabaseSingleton.GetInstance().SimpanSkorUser(
                UserSession.Instance.CurrentUser.IdUser,
                GameManager.Instance.CurrentLevel,
                persentase);

            TampilkanHasilEvaluasi(
                score,
                jumlahBenar,
                persentase);

            GameManager.Instance.AlurSaatIni =
                AlurGame.LEVEL_MEMILIH_KATA;
        }

        private int HitungScore(DataSoal soal)
        {
            int score = 0;

            foreach (Button btn in flpWordContainer.Controls.OfType<Button>())
            {
                bool dipilih = btn.BackColor == Color.DeepSkyBlue;

                if (!dipilih)
                    continue;

                if (soal.OpsiKata.TryGetValue(btn.Text, out bool benar))
                {
                    score = scoreStrategy.HitungScore(score, benar);
                }
            }

            return Math.Max(0, score);
        }

        private void TampilkanHasilEvaluasi(
            int totalBenar,
            int jumlahTarget,
            int skorAkhir)
        {
            MessageBox.Show(
                $"Evaluasi Penyelesaian\n\n" +
                $"Kata benar : {totalBenar} dari {jumlahTarget}\n" +
                $"Total Score : {skorAkhir}%",
                "Hasil Penilaian",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni =
                AlurGame.LEVEL_MEMILIH_KATA;
        }
    }
}