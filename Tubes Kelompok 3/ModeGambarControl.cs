using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeGambarControl : UserControl
    {
        private const string QuestionFilePath = "questions.json";

        // MENYIMPAN SEMUA SOAL
        private readonly List<QuestionItem<object>> questions =
            new List<QuestionItem<object>>();

        // SOAL YANG SEDANG TAMPIL
        private QuestionItem<object> currentQuestion;

        // SCORE
        private int score;

        private readonly Random random = new Random();

        public ModeGambarControl()
        {
            InitializeComponent();
            Load += ModeGambarControl_Load;
        }

        // LOAD AWAL
        private void ModeGambarControl_Load(
            object sender,
            EventArgs e)
        {
            LoadQuestionsFromJson();
            LoadQuestion();
        }

        // LOAD SOAL DARI JSON
        private void LoadQuestionsFromJson()
        {
            if (!File.Exists(QuestionFilePath))
            {
                MessageBox.Show(
                    "File questions.json tidak ditemukan.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var json = File.ReadAllText(QuestionFilePath);

            var data =
                JsonConvert.DeserializeObject<List<QuestionData>>(json);

            if (data == null)
            {
                MessageBox.Show(
                    "Data soal tidak valid.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            foreach (var item in data)
            {
                var image = GetImage(item.ImageName);

                if (image == null)
                {
                    continue;
                }

                questions.Add(
                    new QuestionItem<object>(
                        image,
                        item.Answers));
            }
        }

        // AMBIL GAMBAR DARI RESOURCES
        private Image GetImage(string imageName)
        {
            return Properties.Resources
                .ResourceManager
                .GetObject(imageName) as Image;
        }

        // LOAD SOAL RANDOM
        private void LoadQuestion()
        {
            if (questions.Count == 0)
            {
                MessageBox.Show(
                    "Tidak ada soal yang tersedia.",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            var index = random.Next(questions.Count);

            currentQuestion = questions[index];

            pbQuestion.Image = currentQuestion.SoalGambar;
        }

        // CHECK JAWABAN
        private void btnCheck_Click(
            object sender,
            EventArgs e)
        {
            if (currentQuestion == null)
            {
                return;
            }

            var userInput = txtAnswer.Text.Trim();

            bool correct =
                currentQuestion.JawabanBenar.Any(answer =>
                    string.Equals(
                        answer?.ToString(),
                        userInput,
                        StringComparison.OrdinalIgnoreCase));

            if (correct)
            {
                score++;
                MessageBox.Show("Correct!");
            }
            else
            {
                score--;
                MessageBox.Show("Wrong!");
            }

            lblScore.Text = $"Score : {score}";

            txtAnswer.Clear();

            LoadQuestion();
        }

        // BUTTON KEMBALI
        private void btnPilihMenuPilihMode_Click(
            object sender,
            EventArgs e)
        {
            GameManager.Instance.AlurSaatIni =
                AlurGame.MENU_PILIH_MODE;
        }

        // EVENT LABEL
        private void lblQuestion_Click(
            object sender,
            EventArgs e)
        {
        }

        private void lblAnswer_Click(
            object sender,
            EventArgs e)
        {
        }

        private void ModeGambarControl_Load_1(object sender, EventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {
            
        }
    }

    // GENERIC CLASS
    public class QuestionItem<T>
    {
        public Image SoalGambar { get; set; }

        public List<T> JawabanBenar { get; set; }

        public QuestionItem(
            Image soalGambar,
            List<T> jawabanBenar)
        {
            SoalGambar = soalGambar;
            JawabanBenar = jawabanBenar;
        }
    }
}