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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            GameManager.OnAlurChanged += HandlePerubahanAlur;

            GameManager.AlurSaatIni = AlurGame.HalamanLogin;
        }
        public void SwitchView(UserControl newView)
        {
            containerPanel.Controls.Clear(); // Membersihkan tampilan sebelumnya
            newView.Dock = DockStyle.Fill;   // Menyesuaikan ukuran windows menjadi full
            containerPanel.Controls.Add(newView); // Menampilkan layar yang baru
        }

        private void HandlePerubahanAlur(AlurGame alurBaru)
        {
            switch (alurBaru)
            {
                case AlurGame.HalamanLogin:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : HALAMAN LOGIN");
                    SwitchView(new HalamanLoginControl());
                    break;
                case AlurGame.HalamanRegistrasi:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : HALAMAN REGISTRASI");
                    SwitchView(new HalamanRegistrasiControl());
                    break;
                case AlurGame.MAIN_MENU:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : MAIN MENU");
                    SwitchView(new MainMenuControl());
                    break;
                case AlurGame.MENU_PILIH_MODE:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : MENU PILIH MODE");
                    SwitchView(new PilihModeControl());
                    break;
                case AlurGame.MODE_MEMILIH_KATA:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : MODE MEMILIH KATA");
                    SwitchView(new ModeMemilihKataControl());
                    break;
                case AlurGame.MODE_GAMBAR:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : MODE GAMBAR");
                    SwitchView(new ModeGambarControl());
                    break;
                case AlurGame.MODE_MENCOCOKAN_KATA:
                    System.Diagnostics.Debug.WriteLine("Alur Saat Ini : MODE MENCOCOKAN KATA");
                    SwitchView(new ModeMencocokanKataControl());
                    break;
            }
        }
    }
}
