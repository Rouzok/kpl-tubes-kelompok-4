using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeGambarControl : UserControl
    {
        // MENYIMPAN SEMUA SOAL
        private List<QuestionItem<object>> questions =
            new List<QuestionItem<object>>();

        // SOAL YANG SEDANG TAMPIL
        private QuestionItem<object> currentQuestion;

        // SCORE
        private int score = 0;

        Random rnd = new Random();

        public ModeGambarControl()
        {
            InitializeComponent();

            this.Load += ModeGambarControl_Load;
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
            string json =
                File.ReadAllText("questions.json");

            List<QuestionData> data =
                JsonConvert.DeserializeObject
                <List<QuestionData>>(json);

            foreach (var item in data)
            {
                questions.Add(
                    new QuestionItem<object>(
                        GetImage(item.ImageName),

                        item.Answers
                    )
                );
            }
        }

        // AMBIL GAMBAR DARI RESOURCES
        private Image GetImage(string imageName)
        {
            return (Image)Properties.Resources
                .ResourceManager
                .GetObject(imageName);
        }

        // LOAD SOAL RANDOM
        private void LoadQuestion()
        {
            int index = rnd.Next(questions.Count);

            currentQuestion = questions[index];

            pbQuestion.Image =
                currentQuestion.SoalGambar;
        }

        // CHECK JAWABAN
        private void btnCheck_Click(
            object sender,
            EventArgs e)
        {
            string userInput =
                txtAnswer.Text.Trim().ToLower();

            bool correct = false;

            foreach (var answer
                in currentQuestion.JawabanBenar)
            {
                if (answer.ToString().ToLower()
                    == userInput)
                {
                    correct = true;
                }
            }

            // HASIL
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

            lblScore.Text =
                "Score : " + score;

            txtAnswer.Clear();

            LoadQuestion();
        }

        // BUTTON KEMBALI
        private void btnPilihMenuPilihMode_Click(
            object sender,
            EventArgs e)
        {
            GameManager.AlurSaatIni =
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