using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tubes_Kelompok_3.Interface;

namespace Tubes_Kelompok_3
{
    // Mengimplementasikan antarmuka IObserver
    public partial class MainForm : Form, IGameObserver<AlurGame>
    {
        // Struktur data Table-Driven
        private readonly Dictionary<AlurGame, Func<UserControl>> _tabelTransisiView;

        public MainForm()
        {
            InitializeComponent();

            _tabelTransisiView = new Dictionary<AlurGame, Func<UserControl>>
            {
                { AlurGame.MAIN_MENU, () => new MainMenuControl() },
                { AlurGame.MENU_PILIH_MODE, () => new PilihModeControl() },
                { AlurGame.MODE_MEMILIH_KATA, () => new ModeMemilihKataControl() },
                { AlurGame.MODE_GAMBAR, () => new ModeGambarControl() },
                { AlurGame.MODE_MENCOCOKAN_KATA, () => new ModeMencocokanKataControl() }
            };

            // Mendaftarkan MainForm sebagai Observer ke dalam Subject (GameManager)
            GameManager.Attach(this);

            GameManager.AlurSaatIni = AlurGame.MAIN_MENU;
        }

        public void SwitchView(UserControl newView)
        {
            // PRECONDITION (DbC): View baru harus ada
            if (newView == null)
            {
                throw new ArgumentNullException(nameof(newView), "Kontrak Dilanggar: MainForm memerlukan UserControl valid.");
            }

            foreach (Control control in containerPanel.Controls)
            {
                control.Dispose();
            }
            containerPanel.Controls.Clear();

            newView.Dock = DockStyle.Fill;
            containerPanel.Controls.Add(newView);

            // POSTCONDITION (DbC): Container harus memiliki tepat 1 control
            System.Diagnostics.Debug.Assert(containerPanel.Controls.Count == 1, "Kontrak Pasca-kondisi: Container gagal memuat view.");
        }

        // Implementasi kontrak dari IObserver<AlurGame>
        public void UpdateData(AlurGame alurBaru)
        {
            // Defensive Programming: Sinkronisasi operasi lintas-utas
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<AlurGame>(UpdateData), alurBaru);
                return;
            }

            // Eksekusi Table-Driven tanpa percabangan switch-case
            if (_tabelTransisiView.TryGetValue(alurBaru, out Func<UserControl> instansiasiView))
            {
                System.Diagnostics.Debug.WriteLine($"[Observer Notification] Transisi ke : {alurBaru}");
                SwitchView(instansiasiView());
            }
            else
            {
                // Fallback / Defensive programming
                System.Diagnostics.Debug.WriteLine($"[ERROR] Transisi state tidak diregistrasi di tabel: {alurBaru}");
                throw new ArgumentOutOfRangeException(nameof(alurBaru), alurBaru, "Transisi state di luar definisi tabel transisi.");
            }
        }
    }
}