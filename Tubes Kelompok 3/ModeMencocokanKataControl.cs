using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeMencocokanKataControl : UserControl
    {
        Dictionary<string, string> wordTable;
        List<string> questions;
        List<string> answers;
        List<Button> btnInggrisList;
        List<Button> btnIndoList;

        int score = 0;
        string selectedQuestion = "";
        Random rand = new Random();

        public ModeMencocokanKataControl()
        {
            InitializeComponent();
            LoadData();
            SetupButtons();
            LoadQuestion();
        }

        void LoadData()
        {
            wordTable = new Dictionary<string, string>()
            {
                {"Apple", "Apel"},
                {"Book", "Buku"},
                {"Cat", "Kucing"},
                {"Dog", "Anjing"},
                {"Eagle", "Elang"},
                {"Fire", "Api"},
            };

            questions = wordTable.Keys.ToList();
            answers = wordTable.Values.ToList();

            btnInggrisList = new List<Button>()
            {
                btnInggris1, btnInggris2, btnInggris3,
                btnInggris4, btnInggris5, btnInggris6
            };

            btnIndoList = new List<Button>()
            {
                btnIndo1, btnIndo2, btnIndo3,
                btnIndo4, btnIndo5, btnIndo6
            };
        }

        void SetupButtons()
        {
            // event tombol Inggris
            foreach (var btn in btnInggrisList)
            {
                btn.Click += BtnInggris_Click;
            }

            // event tombol Indo
            foreach (var btn in btnIndoList)
            {
                btn.Click += BtnIndo_Click;
            }
        }

        void LoadQuestion()
        {
           
            for (int i = 0; i < btnInggrisList.Count; i++)
            {
                btnInggrisList[i].Text = questions[i];
                btnInggrisList[i].Enabled = true;
            }

            // shuffle jawaban
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
            Button btn = sender as Button; 
            selectedQuestion = btn.Text; //menyimpan kata 
        }

        private void BtnIndo_Click(object sender, EventArgs e)
        {
            if (selectedQuestion == "")
            {
                MessageBox.Show("Pilih kata Inggris dulu!");
                return;
            }

            Button btn = sender as Button;
            string selectedAnswer = btn.Text;

            string correct = wordTable[selectedQuestion];

            if (selectedAnswer == correct)
            {
                score++;
                MessageBox.Show("Benar!");

                // disable pasangan yang sudah benar
                DisableMatchedButtons(selectedQuestion, selectedAnswer);
            }
            else
            {
                score--; // atau score -= 1;
                MessageBox.Show($"Salah! Skor -1\nJawaban benar: {correct}");
            }

            selectedQuestion = "";
            //lblScore.Text = $"Score: {score}";
            selectedQuestion = "";
            lblScore.Text = $"Score: {score}";

            // cek apakah game selesai
            if (score == wordTable.Count)
            {
                MessageBox.Show($"Game selesai!\nSkor: {score}/{wordTable.Count}");
            }
        }

        void DisableMatchedButtons(string question, string answer)
        {
            foreach (var btn in btnInggrisList)
            {
                if (btn.Text == question)
                    btn.Enabled = false;
            }

            foreach (var btn in btnIndoList)
            {
                if (btn.Text == answer)
                    btn.Enabled = false;
            }
        }

        void Shuffle(List<string> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}