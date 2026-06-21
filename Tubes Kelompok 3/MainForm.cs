using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tubes_Kelompok_3.Interface;

namespace Tubes_Kelompok_3
{
    public partial class MainForm : Form, IGameObserver<AlurGame>
    {
        private const string ErrorViewNull = "Kontrak Dilanggar: MainForm memerlukan UserControl valid.";
        private const string ErrorTransisiTidakDikenal = "Transisi state di luar definisi tabel transisi.";
        private const string PesanAssertContainer = "Kontrak Pasca-kondisi: Container gagal memuat view.";

        // Struktur data Table-Driven
        private readonly Dictionary<AlurGame, Func<UserControl>> _tabelTransisiView;

        public MainForm()
        {
            InitializeComponent();

            _tabelTransisiView = new Dictionary<AlurGame, Func<UserControl>>
            {
                { AlurGame.HalamanLogin, () => new HalamanLoginControl() },
                { AlurGame.HalamanRegistrasi, () => new HalamanRegistrasiControl() },
                { AlurGame.MAIN_MENU, () => new MainMenuControl() },
                { AlurGame.MENU_PILIH_MODE, () => new PilihModeControl() },
                { AlurGame.MODE_MEMILIH_KATA, () => new ModeMemilihKataControl() },
                { AlurGame.MODE_GAMBAR, () => new ModeGambarControl() },
                { AlurGame.MODE_MENCOCOKAN_KATA, () => new ModeMencocokanKataControl() },
                
                { AlurGame.MODE_GAMBAR_LEVEL1, () => new ModeGambarLevel1() },
                { AlurGame.MODE_GAMBAR_LEVEL2, () => new ModeGambarLevel2() },
                { AlurGame.MODE_GAMBAR_LEVEL3, () => new ModeGambarLevel3() },

                { AlurGame.MODE_MEMILIHKATA_LEVEL1, () => new ModeMemilihKataLevel1() },
                { AlurGame.MODE_MEMILIHKATA_LEVEL2, () => new ModeMemilihKataLevel2() },
                { AlurGame.MODE_MEMILIHKATA_LEVEL3, () => new ModeMemilihKataLevel3() },

                { AlurGame.MODE_MENCOCOKKANKATA_LEVEL1, () => new ModeMencocokkanKataLevel1() },
                { AlurGame.MODE_MENCOCOKKANKATA_LEVEL2, () => new ModeMencocokkanKataLevel2() },
                { AlurGame.MODE_MENCOCOKKANKATA_LEVEL3, () => new ModeMencocokkanKataLevel3() }
            };

            // Mendaftarkan MainForm sebagai Observer ke dalam Subject (GameManager)
            GameManager.Instance.Attach(this);

            GameManager.Instance.AlurSaatIni = AlurGame.HalamanLogin;
        }

        public void SwitchView(UserControl newView)
        {
            // PRECONDITION (DbC): View baru harus ada
            if (newView == null)
            {
                throw new ArgumentNullException(nameof(newView), ErrorViewNull);
            }

            foreach (Control control in containerPanel.Controls)
            {
                control.Dispose();
            }
            BersihkanContainer();

            newView.Dock = DockStyle.Fill;
            containerPanel.Controls.Add(newView);

            // POSTCONDITION (DbC): Container harus memiliki tepat 1 control
            System.Diagnostics.Debug.Assert(containerPanel.Controls.Count == 1, PesanAssertContainer);
        }

        private void BersihkanContainer()
        {
            while (containerPanel.Controls.Count > 0)
            {
                containerPanel.Controls[0].Dispose();
            }
        }

        public void UpdateData(AlurGame alurBaru)
        {
            // Defensive Programming: Sinkronisasi operasi lintas-utas
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<AlurGame>(UpdateData), alurBaru);
                return;
            }

            if (_tabelTransisiView.TryGetValue(alurBaru, out Func<UserControl> instansiasiView)){
                System.Diagnostics.Debug.WriteLine($"[Observer Notification] Transisi ke : {alurBaru}");
                SwitchView(instansiasiView());
            }else{
                // Defensive programming
                System.Diagnostics.Debug.WriteLine($"[ERROR] Transisi state tidak diregistrasi di tabel: {alurBaru}");
                throw new ArgumentOutOfRangeException(nameof(alurBaru), alurBaru, ErrorTransisiTidakDikenal);
            }
        }

        private void containerPanel_Paint(
            object sender,
            PaintEventArgs e)
        {

        }
    }
}