using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class MainForm : Form
    {
        private Dictionary<AlurGame, Func<UserControl>> routeTable;

        public MainForm()
        {
            InitializeComponent();

            routeTable = new Dictionary<AlurGame, Func<UserControl>>
            {
                { AlurGame.MAIN_MENU, () => new MainMenuControl() },
                { AlurGame.MENU_PILIH_MODE, () => new PilihModeControl() },

                { AlurGame.MODE_GAMBAR, () => new ModeGambarControl() },
                { AlurGame.MODE_MEMILIH_KATA, () => new ModeMemilihKataControl() },
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

            GameManager.OnAlurChanged += HandlePerubahanAlur;

            GameManager.AlurSaatIni = AlurGame.MAIN_MENU;
        }

        public void SwitchView(UserControl newView)
        {
            containerPanel.Controls.Clear();

            newView.Dock = DockStyle.Fill;

            containerPanel.Controls.Add(newView);
        }

        private void HandlePerubahanAlur(
            AlurGame alurBaru)
        {
            if (routeTable.ContainsKey(alurBaru))
            {
                SwitchView(routeTable[alurBaru]());
            }
        }

        private void containerPanel_Paint(
            object sender,
            PaintEventArgs e)
        {

        }
    }
}