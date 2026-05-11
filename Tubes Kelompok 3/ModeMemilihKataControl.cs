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
    public partial class ModeMemilihKataControl : UserControl
    {
        // Struktur Data Table-Driven
        private class DataSoal
        {
            public string JudulSoal { get; set; }
            public Dictionary<string, bool> OpsiKata { get; set; }
        }

        private List<DataSoal> tabelSoal;
        private int indeksSoalAktif = 0;

        public ModeMemilihKataControl()
        {
            InitializeComponent();
            InisialisasiDataSoal();
            TampilkanSoal(indeksSoalAktif);

            // Mendaftarkan event handler untuk tombol submit
            btnSubmit.Click += BtnSubmit_Click;
        }

        // Inisialisasi Data Soal
        private void InisialisasiDataSoal()
        {
            tabelSoal = new List<DataSoal>
            {
                new DataSoal
                {
                    JudulSoal = "Select the real English words in this list",
                    OpsiKata = new Dictionary<string, bool>
                    {
                        { "thelf", false },
                        { "wainch", false },
                        { "going", true },
                        { "anslip", false },
                        { "anspe", false },
                        { "see", true },
                        { "an", true },
                        { "good", true },
                        { "caffie", false },
                        { "sier", false },
                        { "elm", true },
                        { "nineteen", true },
                        { "water", true },
                        { "brother", true },
                        { "easy", true },
                        { "give", true },
                        { "new", true },
                        { "daiy", false }
                    }
                }
            };
        }

        // Memuat Antarmuka Berdasarkan Data Tabel
        private void TampilkanSoal(int indeks)
        {
            // PRECONDITION: Indeks harus dalam jangkauan tabelSoal
            if (tabelSoal == null || indeks < 0 || indeks >= tabelSoal.Count){
                throw new IndexOutOfRangeException($"Kontrak Dilanggar: Indeks soal {indeks} di luar jangkauan tabelSoal.");
            }

            foreach (Control control in flpWordContainer.Controls){
                control.Dispose();
            }
            flpWordContainer.Controls.Clear();

            DataSoal soal = tabelSoal[indeks];
            lblTitle.Text = soal.JudulSoal;

            // INVARIANT: OpsiKata tidak boleh kosong
            if (soal.OpsiKata.Count == 0){
                throw new InvalidOperationException("Kontrak Invarian Dilanggar: Data soal tidak memiliki opsi kata.");
            }

            foreach (KeyValuePair<string, bool> item in soal.OpsiKata){
                Button btnWord = new Button();
                btnWord.Text = item.Key;
                btnWord.Size = new Size(100, 40);
                btnWord.Click += WordButton_Click;
                flpWordContainer.Controls.Add(btnWord);
            }
        }

        // Logika tombol ketika ditekan
        private void WordButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null){
                if (clickedButton.BackColor == Color.White){
                    clickedButton.BackColor = Color.DeepSkyBlue;
                    clickedButton.ForeColor = Color.White;
                }else{
                    clickedButton.BackColor = Color.White;
                    clickedButton.ForeColor = Color.Black;
                }
            }
        }

        // Logika tombol dan Pencatatan Skor
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Prekondisi untuk eksekusi penilaian
            if (tabelSoal == null || indeksSoalAktif < 0 || indeksSoalAktif >= tabelSoal.Count){
                MessageBox.Show("Terjadi kesalahan sistem: Data soal tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSoal soalAktif = tabelSoal[indeksSoalAktif];
            int totalBenar = 0;
            int totalSalah = 0;
            int jumlahJawabanBenarSeharusnya = 0;

            foreach (bool isBenar in soalAktif.OpsiKata.Values){
                if (isBenar) jumlahJawabanBenarSeharusnya++;
            }

            foreach (Control control in flpWordContainer.Controls)
            {
                if (control is Button btnWord)
                {
                    string kata = btnWord.Text;
                    bool statusTerpilih = (btnWord.BackColor == Color.DeepSkyBlue);

                    // Penanganan Exception Pencarian Dictionary
                    if (soalAktif.OpsiKata.TryGetValue(kata, out bool statusValiditasTabel))
                    {
                        if (statusTerpilih && statusValiditasTabel){
                            totalBenar++;
                        }else if (statusTerpilih && !statusValiditasTabel){
                            totalSalah++;
                        }
                    }else{
                        System.Diagnostics.Debug.WriteLine($"[WARNING] Evaluasi dilewati: Kata '{kata}' tidak ditemukan dalam referensi OpsiKata.");
                    }
                }
            }

            int skorAkhir = totalBenar - totalSalah;
            if (skorAkhir < 0) skorAkhir = 0;

            string pesanHasil = $"Evaluasi Penyelesaian:\n\n" +
                                $"- Kata benar yang ditemukan: {totalBenar} dari {jumlahJawabanBenarSeharusnya}\n" +
                                $"- Kesalahan pemilihan: {totalSalah}\n" +
                                $"- Total Skor: {skorAkhir}";

            MessageBox.Show(pesanHasil, "Hasil Penilaian", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
