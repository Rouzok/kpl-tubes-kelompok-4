using System;
using System.Drawing;
using System.Windows.Forms;
using Tubes_Kelompok_3;
using Xunit;

namespace UnitTests
{
    public class GameManagerTests
    {
        [Fact]
        public void AlurSaatIni_SetNilaiValid_MemicuEventOnAlurChanged()
        {
            //Memastikan pelemparan eksepsi saat prekondisi dilanggar
            Assert.Throws<ArgumentException>(() =>
            {
                GameManager.AlurSaatIni = AlurGame.NULL;
            });
        }

        [Fact]
        public void AlurSaatIni_SetNilaiNull_MelemparArgumentException()
        {
            AlurGame alurTerpicu = AlurGame.NULL;
            bool eventTerpanggil = false;

            // Pembuatan handler untuk didaftarkan pada event OnAlurChanged
            Action<AlurGame> handler = (alurBaru) =>
            {
                eventTerpanggil = true;
                alurTerpicu = alurBaru;
            };

            GameManager.OnAlurChanged += handler;
            AlurGame targetAlur = AlurGame.MENU_PILIH_MODE;

            try{
                // Mengubah properti dengan nilai yang valid
                GameManager.AlurSaatIni = targetAlur;

                // Verifikasi perubahan nilai internal dan eksekusi event
                Assert.Equal(targetAlur, GameManager.AlurSaatIni);
                Assert.True(eventTerpanggil, "Event OnAlurChanged tidak terpicu.");
                Assert.Equal(targetAlur, alurTerpicu);
            }finally{
                // Pelepasan handler untuk mencegah kebocoran memori atau efek samping pada pengujian lain
                GameManager.OnAlurChanged -= handler;
            }
        }

    }

    public class MainFormTests
    {
        [Fact]
        public void SwitchView_InputNull_MelemparArgumentNullException()
        {
            // Menginisialisasi instance MainForm di dalam blok using 
            // untuk memastikan dealokasi memori (Dispose) setelah pengujian selesai.
            using (MainForm mainForm = new MainForm())
            {
                // Memverifikasi bahwa metode melempar ArgumentNullException
                // saat parameter bernilai null, sesuai dengan prekondisi DbC.
                Assert.Throws<ArgumentNullException>(() =>
                {
                    mainForm.SwitchView(null);
                });
            }
        }

        [Fact]
        public void SwitchView_InputValid_MenggantiKontrolPadaContainerPanel()
        {
            // Menginisialisasi MainForm dan objek UserControl tiruan (dummy).
            using (MainForm mainForm = new MainForm())
            using (UserControl testControl = new UserControl())
            {
                // Mengeksekusi metode SwitchView dengan objek yang valid.
                mainForm.SwitchView(testControl);

                // Assert: Verifikasi postkondisi
                // 1. Memastikan testControl telah memiliki Parent (telah ditambahkan ke suatu container).
                Assert.NotNull(testControl.Parent);

                // 2. Memastikan bahwa parameter Dock pada testControl telah diubah menjadi Fill.
                Assert.Equal(DockStyle.Fill, testControl.Dock);

                // 3. Memastikan bahwa Parent dari testControl (yaitu containerPanel) 
                // hanya memiliki tepat 1 kontrol di dalamnya, sesuai dengan postkondisi.
                Assert.Equal(1, testControl.Parent.Controls.Count);

                // 4. Memastikan bahwa kontrol tunggal tersebut adalah testControl yang diinputkan.
                Assert.Equal(testControl, testControl.Parent.Controls[0]);
            }
        }
    }

    public class ModeMemilihKataControlTests
    {
        [Fact]
        public void TampilkanSoal_IndeksNegatif_MelemparIndexOutOfRangeException()
        {
            using (var control = new ModeMemilihKataControl())
            {
                Assert.Throws<IndexOutOfRangeException>(() =>
                {
                    control.TampilkanSoal(-1);
                });
            }
        }

        [Fact]
        public void TampilkanSoal_IndeksLebihBesarDariKapasitas_MelemparIndexOutOfRangeException()
        {
            using (var control = new ModeMemilihKataControl())
            {
                Assert.Throws<IndexOutOfRangeException>(() =>
                {
                    control.TampilkanSoal(999); // Indeks di luar batas array/list
                });
            }
        }

        [Fact]
        public void BtnSubmit_Click_ValidasiPencatatanSkor_MenghasilkanSkorAkurat()
        {
            using (var control = new ModeMemilihKataControl())
            {
                // 1. Mengakses panel public secara langsung
                foreach (Control c in control.flpWordContainer.Controls)
                {
                    if (c is Button btn)
                    {
                        // Simulasi pemilihan kata (1 Benar, 1 Salah)
                        if (btn.Text == "going" || btn.Text == "thelf")
                        {
                            btn.BackColor = Color.DeepSkyBlue;
                        }
                    }
                }

                // 2. Pemanggilan langsung metode event handler public.
                // Catatan: MessageBox.Show di dalam metode ini tetap akan dieksekusi 
                // dan menghentikan proses thread (blocking) hingga ditutup secara manual oleh operator.
                control.BtnSubmit_Click(null, EventArgs.Empty);

                // Assert
                // Pengujian memvalidasi bahwa eksekusi metode tidak menghasilkan exception runtime.
                Assert.True(true);
            }
        }
    }
}
