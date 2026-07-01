using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeGambarControl : UserControl, IGameMode
    {
        private List<QuestionItem> questions = new List<QuestionItem>();

        // Melacak soal yang sedang dikerjakan agar tidak berulang
        private int currentQuestionIndex = 0;

        public class QuestionItem
        {
            public Image SoalGambar { get; set; }
            public string JawabanBenar { get; set; }

            public QuestionItem(Image soalGambar, string jawabanBenar)
            {
                SoalGambar = soalGambar;
                JawabanBenar = jawabanBenar;
            }
        }

        private int score;

        public ModeGambarControl()
        {
            InitializeComponent();
            Load += ModeGambarControl_Load;
        }

        private void ModeGambarControl_Load(object sender, EventArgs e)
        {
            score = 0;
            currentQuestionIndex = 0;
            lblScore.Text = $"Score : {score}";

            LoadQuestionsFromDatabase();
            ShowNextQuestion();
        }

        private void LoadQuestionsFromDatabase()
        {
            questions.Clear();

            int levelSaatIni = GameManager.Instance.CurrentLevel;

            var rawData = DatabaseSingleton.GetInstance().GetSoalModeGambar(levelSaatIni);

            if (rawData == null || rawData.Count == 0)
            {
                MessageBox.Show(
                    $"Data soal untuk Level {levelSaatIni} tidak ditemukan di database.",
                    "Error Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            foreach (var item in rawData)
            {
                Image imageRes = GetImage(item.PathGambar);

                if (imageRes != null)
                {
                    questions.Add(new QuestionItem(imageRes, item.KunciJawaban));
                }
                else
                {
                    // Defensive Programming: Melaporkan anomali nama file pada tabel
                    System.Diagnostics.Debug.WriteLine($"[Peringatan] Gambar {item.PathGambar} tidak ditemukan di Resources.");
                }
            }

            // (Shuffling) menggunakan algoritma berbasis LINQ
            questions = questions.OrderBy(x => Guid.NewGuid()).ToList();
        }

        // Resolusi ekstraksi dari direktori Assembly (Resources.resx)
        private Image GetImage(string imageName)
        {
            return Properties.Resources
                .ResourceManager
                .GetObject(imageName) as Image;
        }

        private void ShowNextQuestion()
        {
            if (questions.Count == 0) return;

            if (currentQuestionIndex >= questions.Count)
            {
                MessageBox.Show(
                    $"Kuis Selesai!\nSkor Akhir Anda: {score} dari {questions.Count}",
                    "Evaluasi Selesai",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                int idUserAktif = UserSession.Instance.CurrentUser.IdUser;
                int skorPersentase = (int)Math.Round((double)Math.Max(0, score) / questions.Count * 100);
                DatabaseSingleton.GetInstance().SimpanSkorUser(idUserAktif, GameManager.Instance.CurrentLevel, skorPersentase);

                GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_GAMBAR;
                return;
            }

            // Memuat soal berdasarkan antrean indeks berjalan
            var currentQuestion = questions[currentQuestionIndex];
            pbQuestion.Image = currentQuestion.SoalGambar;
            txtAnswer.Clear();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (questions.Count == 0 || currentQuestionIndex >= questions.Count) return;

            var currentQuestion = questions[currentQuestionIndex];
            var userInput = txtAnswer.Text.Trim();

            // Evaluasi kecocokan string yang tidak sensitif terhadap kapitalisasi (Case-Insensitive)
            bool correct = string.Equals(currentQuestion.JawabanBenar, userInput, StringComparison.OrdinalIgnoreCase);

            if (correct)
            {
                score++;
                MessageBox.Show("Correct!", "Evaluasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Pengaturan skor dapat dimodifikasi sesuai spesifikasi apakah salah bernilai negatif
                MessageBox.Show($"Wrong! Jawaban yang benar adalah: {currentQuestion.JawabanBenar}", "Evaluasi Sistem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            lblScore.Text = $"Score : {score}";

            // Maju ke antrean soal berikutnya
            currentQuestionIndex++;
            ShowNextQuestion();
        }

        private void btnPilihMenuPilihMode_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_GAMBAR;
        }

        private void lblQuestion_Click(object sender, EventArgs e) { }
        private void lblAnswer_Click(object sender, EventArgs e) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni = AlurGame.LEVEL_GAMBAR;
        }

        private void ModeGambarControl_Load_1(object sender, EventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {
            
        }
        public UserControl GetControl()
        {
            return this;
        }
    }

}