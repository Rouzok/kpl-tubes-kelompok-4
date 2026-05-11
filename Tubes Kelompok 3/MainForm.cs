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

            GameManager.AlurSaatIni = AlurGame.MAIN_MENU;
        }
        public void SwitchView(UserControl newView)
        {
            // PRECONDITION: View baru harus ada (tidak boleh null)
            if (newView == null){
                throw new ArgumentNullException(nameof(newView), "Kontrak Dilanggar: MainForm memerlukan UserControl valid untuk ditampilkan.");
            }

            foreach (Control control in containerPanel.Controls)
            {
                control.Dispose();
            }
            containerPanel.Controls.Clear();

            newView.Dock = DockStyle.Fill;
            containerPanel.Controls.Add(newView);

            // POSTCONDITION: Container harus memiliki tepat 1 control
            System.Diagnostics.Debug.Assert(containerPanel.Controls.Count == 1, "Kontrak Pasca-kondisi: Container gagal memuat view baru.");
        }

        private void HandlePerubahanAlur(AlurGame alurBaru)
        {
            if (this.InvokeRequired){
                this.Invoke(new Action<AlurGame>(HandlePerubahanAlur), alurBaru);
                return;
            }

            switch (alurBaru)
            {
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
                default:
                    System.Diagnostics.Debug.WriteLine($"[ERROR] Transisi state tidak dikenal: {alurBaru}");
                    throw new ArgumentOutOfRangeException(nameof(alurBaru), alurBaru, "Transisi state di luar definisi AlurGame.");
            }
        }
    }
}
