using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeMencocokanKataControl : UserControl, IGameMode
    {
        private readonly IScoreStrategy scoreStrategy;
        public event Action<int> OnScoreChanged;
        public event Action<int> OnGameFinished;

        private Dictionary<string, string> wordTable;
        private List<string> questions;
        private List<string> answers;

        private List<Button> btnInggrisList;
        private List<Button> btnIndoList;

        private int score = 0;
        private int _pasanganDitemukan = 0;

        private string selectedQuestion = "";
        private Button _tombolKiriTerpilih = null;

        private readonly Random random = new Random();

        public ModeMencocokanKataControl()
        {
            InitializeComponent();
            scoreStrategy = new MencocokkanKataScoreStrategy();

            wordTable = new Dictionary<string, string>();
            questions = new List<string>();
            answers = new List<string>();
            btnInggrisList = new List<Button>();
            btnIndoList = new List<Button>();

            LoadDataDariDatabase();

            if (wordTable.Count > 0)
            {
                RenderTombolDinamis();
            }
        }

        private void LoadDataDariDatabase()
        {
            int levelSaatIni = GameManager.Instance.CurrentLevel;
            var dataDb = DatabaseSingleton.GetInstance().GetSoalMencocokkanKata(levelSaatIni);

            if (dataDb != null)
            {
                string[] arrayKiri = dataDb.EntitasKiri.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] arrayKanan = dataDb.EntitasKanan.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Menggunakan panjang array minimum untuk mencegah eksepsi OutOfBounds jika jumlah data tidak seimbang
                int batasMaksimal = Math.Min(arrayKiri.Length, arrayKanan.Length);

                for (int i = 0; i < batasMaksimal; i++)
                {
                    string kiri = arrayKiri[i].Trim();
                    string kanan = arrayKanan[i].Trim();

                    wordTable[kiri] = kanan;
                    questions.Add(kiri);
                    answers.Add(kanan);
                }
            }
            else
            {
                MessageBox.Show(
                    $"Data soal untuk Level {levelSaatIni} tidak ditemukan di database.",
                    "Kesalahan Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RenderTombolDinamis()
        {
            // Membersihkan sisa kontrol pada memori sebelum merender ulang
            flpKiri.Controls.Clear();
            flpKanan.Controls.Clear();
            btnInggrisList.Clear();
            btnIndoList.Clear();

            for (int i = 0; i < questions.Count; i++)
            {
                Button btnKiri = new Button
                {
                    Text = questions[i],
                    Size = new Size(150, 40),
                    BackColor = Color.White,
                    Margin = new Padding(5)
                };

                btnKiri.Click += BtnInggris_Click;
                btnInggrisList.Add(btnKiri);
                flpKiri.Controls.Add(btnKiri);
            }

            List<string> shuffledAnswers = new List<string>(answers);
            Shuffle(shuffledAnswers);

            for (int i = 0; i < shuffledAnswers.Count; i++)
            {
                Button btnKanan = new Button
                {
                    Text = shuffledAnswers[i],
                    Size = new Size(150, 40),
                    BackColor = Color.White,
                    Margin = new Padding(5)
                };

                btnKanan.Click += BtnIndo_Click;
                btnIndoList.Add(btnKanan);
                flpKanan.Controls.Add(btnKanan);
            }
        }

        private void BtnInggris_Click(object sender, EventArgs e)
        {
            if (_tombolKiriTerpilih != null && _tombolKiriTerpilih.Enabled)
            {
                _tombolKiriTerpilih.BackColor = Color.White;
            }

            _tombolKiriTerpilih = sender as Button;
            _tombolKiriTerpilih.BackColor = Color.DeepSkyBlue;
            selectedQuestion = _tombolKiriTerpilih.Text;
        }

        private void BtnIndo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedQuestion) || _tombolKiriTerpilih == null)
            {
                MessageBox.Show("Pilih kata awal pada lajur kiri terlebih dahulu!", "Validasi Operasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Button btnKananTerpilih = sender as Button;
            string selectedAnswer = btnKananTerpilih.Text;
            string correctAnswer = wordTable[selectedQuestion];

            bool benar = selectedAnswer == correctAnswer;
            score = scoreStrategy.HitungScore(score, benar);
            if (benar)
            {
                _pasanganDitemukan++;

                // Menonaktifkan pasangan yang valid dan memberikan indikator warna hijau
                _tombolKiriTerpilih.Enabled = false;
                _tombolKiriTerpilih.BackColor = Color.LightGreen;

                btnKananTerpilih.Enabled = false;
                btnKananTerpilih.BackColor = Color.LightGreen;
            }
            else
            {
                // Mereset seleksi jika jawaban salah
                _tombolKiriTerpilih.BackColor = Color.White;

                MessageBox.Show(
                    $"Pemetaan Salah! Skor dikurangi.\nPasangan yang valid untuk '{selectedQuestion}' adalah: {correctAnswer}",
                    "Evaluasi Sistem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Mereset state memori penunjuk seleksi
            selectedQuestion = "";
            _tombolKiriTerpilih = null;

            if (lblScore != null)
            {
                lblScore.Text = $"Score: {score}";
            }

            OnScoreChanged?.Invoke(score);

            // Evaluasi kondisi penyelesaian (Terminasi)
            if (_pasanganDitemukan == wordTable.Count && wordTable.Count > 0)
            {
                OnGameFinished?.Invoke(score);

                int skorPersentase = Math.Max(0, (int)Math.Round((double)score / wordTable.Count * 100));
                int idUserAktif = UserSession.Instance.CurrentUser.IdUser;
                int idLevelAktif = GameManager.Instance.CurrentLevel;

                DatabaseSingleton.GetInstance().SimpanSkorUser(idUserAktif, idLevelAktif, skorPersentase);

                MessageBox.Show(
                    $"Game selesai!\nTotal Pasangan: {_pasanganDitemukan}\nSkor Perolehan: {skorPersentase}%",
                    "Informasi Penyelesaian",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_MENCOCOKKAN_KATA;
            }
        }

        private void Shuffle(List<string> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                string temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_MENCOCOKKAN_KATA;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        public UserControl GetControl()
        {
            return this;
        }
    }
}