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
        // MENYIMPAN SEMUA SOAL
        private List<object> questions = new List<object>();

        // MENYIMPAN SOAL YANG SEDANG TAMPIL
        private object currentQuestion;

        // SCORE
        private int score = 0;

        Random rnd = new Random();

        public ModeGambarControl()
        {
            InitializeComponent();

            this.Load += ModeGambarControl_Load;
        }

        // LOAD AWAL
        private void ModeGambarControl_Load(object sender, EventArgs e)
        {
            LoadQuestionsFromJson();

            LoadQuestion();
        }

        // LOAD SOAL DARI JSON
        private void LoadQuestionsFromJson()
        {
            string json = File.ReadAllText("questions.json");

            List<QuestionData> data =
                JsonConvert.DeserializeObject<List<QuestionData>>(json);

            foreach (var item in data)
            {
                // GENERIC INT
                if (item.Type == "int")
                {
                    questions.Add(
                        new QuestionItem<int>(
                            GetImage(item.ImageName),

                            item.Answers
                                .Select(x => Convert.ToInt32(x))
                                .ToList()
                        )
                    );
                }

                // GENERIC STRING
                else if (item.Type == "string")
                {
                    questions.Add(
                        new QuestionItem<string>(
                            GetImage(item.ImageName),

                            item.Answers
                        )
                    );
                }
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

            // JIKA STRING
            if (currentQuestion is QuestionItem<string> qString)
            {
                pbQuestion.Image = qString.SoalGambar;
            }

            // JIKA INT
            else if (currentQuestion is QuestionItem<int> qInt)
            {
                pbQuestion.Image = qInt.SoalGambar;
            }
        }

        // BUTTON CHECK
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string userInput = txtAnswer.Text.Trim();

            bool correct = false;

            // CEK STRING
            if (currentQuestion is QuestionItem<string> qString)
            {
                correct = qString.JawabanBenar.Any(
                    x => x.Equals(
                        userInput,
                        StringComparison.OrdinalIgnoreCase
                    )
                );
            }

            // CEK INT
            else if (currentQuestion is QuestionItem<int> qInt)
            {
                // INPUT ANGKA
                if (int.TryParse(userInput, out int angka))
                {
                    correct = qInt.JawabanBenar.Contains(angka);
                }

                // INPUT HURUF
                else
                {
                    // KONVERSI ANGKA KE HURUF
                    Dictionary<int, string> angkaKeHuruf =
                        new Dictionary<int, string>()
                    {
                        { 1, "satu" },
                        { 2, "dua" },
                        { 3, "tiga" },
                        { 4, "empat" },
                        { 5, "lima" },
                        { 6, "enam" },
                        { 7, "tujuh" },
                        { 8, "delapan" },
                        { 9, "sembilan" },
                        { 10, "sepuluh" }
                    };

                    foreach (int jawaban in qInt.JawabanBenar)
                    {
                        if (angkaKeHuruf.ContainsKey(jawaban))
                        {
                            if (angkaKeHuruf[jawaban]
                                .Equals(userInput,
                                StringComparison.OrdinalIgnoreCase))
                            {
                                correct = true;
                            }
                        }
                    }
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

            lblScore.Text = "Score : " + score;

            txtAnswer.Clear();

            LoadQuestion();
        }

        // BUTTON KEMBALI
        private void btnPilihMenuPilihMode_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MENU_PILIH_MODE;
        }

        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void lblAnswer_Click(object sender, EventArgs e)
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