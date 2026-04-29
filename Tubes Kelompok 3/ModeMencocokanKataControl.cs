using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class ModeMencocokanKataControl : UserControl
    {
        // 🔥 TABLE DRIVEN
        Dictionary<string, string> wordTable;
        List<string> questions;
        List<string> answers;

        int currentIndex = 0;
        int score = 0;
        public ModeMencocokanKataControl()
        {
            InitializeComponent();
            LoadData();      // isi data
            LoadQuestion();  // tampil soal pertama
        }

        private void btnMenuPilihMode_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MENU_PILIH_MODE;
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
                {"Girrafe", "Jerapah"},
                {"Hat", "Topi"},
                {"Island", "Pulau"}
            };

            questions = new List<string>(wordTable.Keys);
            answers = new List<string>(wordTable.Values);
        }

    
        void LoadQuestion()
        {
            if (currentIndex >= questions.Count)
            {
                MessageBox.Show($"Game selesai!\nSkor: {score}/{questions.Count}");
                return;
            }

            // tampilkan soal
            lblQuestion.Text = questions[currentIndex];

            // update skor
            lblScore.Text = $"Score: {score}";

            // bersihkan tombol lama
            panelAnswers.Controls.Clear();

            // shuffle jawaban
            List<string> shuffledAnswers = new List<string>(answers);
            Shuffle(shuffledAnswers);

            // buat tombol dinamis
            foreach (var ans in shuffledAnswers)
            {
                Button btn = new Button();
                btn.Text = ans;
                btn.Width = 120;
                btn.Height = 40;
                btn.Margin = new Padding(5);

                // event klik
                btn.Click += (s, e) => CheckAnswer(ans);

                panelAnswers.Controls.Add(btn);
            }
        }

       
        void CheckAnswer(string selected)
        {
            string correct = wordTable[questions[currentIndex]];

            if (selected == correct)
            {
                score++;
                MessageBox.Show("Benar!");
            }
            else
            {
                MessageBox.Show($"Salah!\nJawaban benar: {correct}");
            }

            currentIndex++;
            LoadQuestion();
        }

  
        void Shuffle(List<string> list)
        {
            Random rand = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
