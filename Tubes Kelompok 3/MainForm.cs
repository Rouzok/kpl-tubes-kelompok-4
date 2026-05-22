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
        // Struktur table-driven memetakan kunci AlurGame ke fungsi instansi
        private readonly Dictionary<AlurGame, Func<UserControl>> _tabelTransisiView;

        public MainForm()
        {
            InitializeComponent();
            // Inisialisasi tabel pemetaan status ke delegasi pembuatan kontrol
            _tabelTransisiView = new Dictionary<AlurGame, Func<UserControl>>
            {
                { AlurGame.MAIN_MENU, () => new MainMenuControl() },
                { AlurGame.MENU_PILIH_MODE, () => new PilihModeControl() },
                { AlurGame.MODE_MEMILIH_KATA, () => new ModeMemilihKataControl() },
                { AlurGame.MODE_GAMBAR, () => new ModeGambarControl() },
                { AlurGame.MODE_MENCOCOKAN_KATA, () => new ModeMencocokanKataControl() }
            };

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
            // sinkronisasi operasi lintas-utas (cross-thread operation safety)
            if (this.InvokeRequired){
                this.Invoke(new Action<AlurGame>(HandlePerubahanAlur), alurBaru);
                return;
            }

            // Eksekusi Table-Driven tanpa percabangan
            if (_tabelTransisiView.TryGetValue(alurBaru, out Func<UserControl> instansiasiView)){
                System.Diagnostics.Debug.WriteLine($"Alur Saat Ini : {alurBaru}");

                SwitchView(instansiasiView());
            }else{
                // Defensive programming untuk menangani nilai enum yang tidak terdaftar
                System.Diagnostics.Debug.WriteLine($"[ERROR] Transisi state tidak diregistrasi di tabel: {alurBaru}");
                throw new ArgumentOutOfRangeException(nameof(alurBaru), alurBaru, "Transisi state di luar definisi tabel transisi.");
            }
        }
    }
}
