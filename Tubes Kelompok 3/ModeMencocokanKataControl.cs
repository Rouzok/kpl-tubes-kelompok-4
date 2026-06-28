using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeMencocokanKataControl : UserControl, IGameMode
    {
        //Observer pattern
        public event Action<int> OnScoreChanged;
        public event Action<int> OnGameFinished;

        private Dictionary<string, string> wordTable;

        private List<string> questions;
        private List<string> answers;

        private List<Button> btnInggrisList;
        private List<Button> btnIndoList;

        private int score = 0;

        private string selectedQuestion = "";

        private readonly Random random = new Random();

        public ModeMencocokanKataControl()
        {
            InitializeComponent();

            LoadData();
            SetupButtons();
            LoadQuestion();
        }

        private void LoadData()
        {
            wordTable = new Dictionary<string, string>()
            {
                { "Apple", "Apel" },
                { "Book", "Buku" },
                { "Cat", "Kucing" },
                { "Dog", "Anjing" },
                { "Eagle", "Elang" },
                { "Fire", "Api" }
            };

            questions = wordTable.Keys.ToList();
            answers = wordTable.Values.ToList();

            btnInggrisList = new List<Button>()
            {
                btnInggris1,
                btnInggris2,
                btnInggris3,
                btnInggris4,
                btnInggris5,
                btnInggris6
            };

            btnIndoList = new List<Button>()
            {
                btnIndo1,
                btnIndo2,
                btnIndo3,
                btnIndo4,
                btnIndo5,
                btnIndo6
            };
        }

        private void SetupButtons()
        {
            // Event tombol bahasa Inggris
            foreach (var button in btnInggrisList)
            {
                button.Click += BtnInggris_Click;
            }

            // Event tombol bahasa Indonesia
            foreach (var button in btnIndoList)
            {
                button.Click += BtnIndo_Click;
            }
        }

        private void LoadQuestion()
        {
            for (int i = 0; i < btnInggrisList.Count; i++)
            {
                btnInggrisList[i].Text = questions[i];
                btnInggrisList[i].Enabled = true;
            }

            // Acak jawaban
            List<string> shuffledAnswers = new List<string>(answers);

            Shuffle(shuffledAnswers);

            for (int i = 0; i < btnIndoList.Count; i++)
            {
                btnIndoList[i].Text = shuffledAnswers[i];
                btnIndoList[i].Enabled = true;
            }
        }

        private void BtnInggris_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            selectedQuestion = button.Text;
        }

        private void BtnIndo_Click(object sender, EventArgs e)
        {
            if (selectedQuestion == "")
            {
                MessageBox.Show("Pilih kata Inggris dulu!");
                return;
            }

            Button button = sender as Button;

            string selectedAnswer = button.Text;

            string correctAnswer = wordTable[selectedQuestion];

            if (selectedAnswer == correctAnswer)
            {
                score++;

                MessageBox.Show("Benar!");

                // Disable pasangan yang sudah benar
                DisableMatchedButtons(
                    selectedQuestion,
                    selectedAnswer);
            }
            else
            {
                score--;

                MessageBox.Show(
                    $"Salah! Skor -1\nJawaban benar: {correctAnswer}");
            }

            selectedQuestion = "";

            lblScore.Text = $"Score: {score}";

            //observer pattern
            OnScoreChanged?.Invoke(score);

            // Cek apakah game selesai
            if (score == wordTable.Count)
            {
                OnGameFinished?.Invoke(score);
                MessageBox.Show(
                    $"Game selesai!\nSkor: {score}/{wordTable.Count}");
            }
        }

        private void DisableMatchedButtons(
            string question,
            string answer)
        {
            foreach (var button in btnInggrisList)
            {
                if (button.Text == question)
                {
                    button.Enabled = false;
                }
            }

            foreach (var button in btnIndoList)
            {
                if (button.Text == answer)
                {
                    button.Enabled = false;
                }
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

        private void label1_Click(
            object sender,
            EventArgs e)
        {
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