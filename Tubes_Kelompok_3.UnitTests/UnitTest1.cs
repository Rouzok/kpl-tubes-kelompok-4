namespace Tubes_Kelompok_3.UnitTests
{
    public class UnitTest1
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
                // TODO: Implementasi pengujian prekondisi input null pada metode SwitchView
            }

            [Fact]
            public void SwitchView_InputValid_MenggantiKontrolPadaContainerPanel()
            {
                // TODO: Implementasi pengujian postkondisi penambahan UserControl baru
            }
        }

        public class ModeMemilihKataControlTests
        {
            [Fact]
            public void TampilkanSoal_IndeksNegatif_MelemparIndexOutOfRangeException()
            {
                // TODO: Implementasi pengujian pengecekan batas indeks bawah
            }

            [Fact]
            public void TampilkanSoal_IndeksLebihBesarDariKapasitas_MelemparIndexOutOfRangeException()
            {
                // TODO: Implementasi pengujian pengecekan batas indeks atas
            }

            [Fact]
            public void BtnSubmit_Click_ValidasiPencatatanSkor_MenghasilkanSkorAkurat()
            {
                // TODO: Implementasi pengujian kalkulasi skor berdasarkan simulasi input boolean
            }
        }
    }
}
