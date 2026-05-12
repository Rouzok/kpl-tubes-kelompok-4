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

    public partial class ModeGambarControl : UserControl
    {
        private List<QuestionItem<string>> questions =
        new List<QuestionItem<string>>();

        private string selectedAnswer = "";

        private int score = 0;

        Random rnd = new Random();



        private void Picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            selectedAnswer = pb.Tag.ToString();
        }



        public ModeGambarControl()
        {

            InitializeComponent();

            this.Load += ModeGambarControl_Load;
        

        }

        private void ModeGambarControl_Load(object sender, EventArgs e)
        {
            questions.Add(new QuestionItem<string>(
                "What is the synonym of Happy?",
                "Joyful",

                Properties.Resources.happy,
                Properties.Resources.sad,
                Properties.Resources.angry,

                "Joyful",
                "Sad",
                "Angry"
            ));

            questions.Add(new QuestionItem<string>(
                "What is the opposite of Big?",
                "Small",

                Properties.Resources.small,
                Properties.Resources.big,
                Properties.Resources.fast,

                "Small",
                "Big",
                "Fast"
            ));

            pb1.Click += Picture_Click;
            pb2.Click += Picture_Click;
            pb3.Click += Picture_Click;

            LoadQuestion();
        }

       
        private void LoadQuestion()
        {
            int index = rnd.Next(questions.Count);

            var q = questions[index];

            lblQuestion.Text = q.Pertanyaan;

            btnCheck.Tag = q.JawabanBenar;

            List<(Image gambar, string jawaban)> pilihan =
                new List<(Image, string)>()
            {
        (q.Gambar1, q.Pilihan1),
        (q.Gambar2, q.Pilihan2),
        (q.Gambar3, q.Pilihan3)
            };

            pilihan = pilihan.OrderBy(x => rnd.Next()).ToList();

            pb1.Image = pilihan[0].gambar;
            pb1.Tag = pilihan[0].jawaban;

            pb2.Image = pilihan[1].gambar;
            pb2.Tag = pilihan[1].jawaban;

            pb3.Image = pilihan[2].gambar;
            pb3.Tag = pilihan[2].jawaban;
        }


       
        private void btnPilihMenuPilihMode_Click(object sender, EventArgs e)
        {
            GameManager.AlurSaatIni = AlurGame.MENU_PILIH_MODE;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string jawabanBenar = btnCheck.Tag.ToString();

            if (selectedAnswer == jawabanBenar) {
                score++;

                MessageBox.Show("Correct!");
            }
            else {
                MessageBox.Show("Wrong!");
            }

            lblScore.Text = "Score : " + score;

            LoadQuestion();
            }
        }
    
    
    // GENERIC CLASS
        public class QuestionItem<T>
        {
        public string Pertanyaan { get; set; }

        public T JawabanBenar { get; set; }

        // gambar pilihan
        public Image Gambar1 { get; set; }
        public Image Gambar2 { get; set; }
        public Image Gambar3 { get; set; }

        // jawaban tiap gambar
        public string Pilihan1 { get; set; }
        public string Pilihan2 { get; set; }
        public string Pilihan3 { get; set; }

        public QuestionItem(
            string pertanyaan,
            T jawabanBenar,
            Image gambar1,
            Image gambar2,
            Image gambar3,
            string pilihan1,
            string pilihan2,
            string pilihan3 )
        {
            Pertanyaan = pertanyaan;
            JawabanBenar = jawabanBenar;

            Gambar1 = gambar1;
            Gambar2 = gambar2;
            Gambar3 = gambar3;

            Pilihan1 = pilihan1;
            Pilihan2 = pilihan2;
            Pilihan3 = pilihan3;

        }

        
    }
}
