using System;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    internal partial class LevelGambarControl : LevelBaseControl
    {
        public LevelGambarControl()
        {
            InitializeComponent();

            LoadLevel();
        }

        private void LoadLevel()
        {
            LoadLevels(
                flowLevel,
                "GAMBAR",
                BtnLevel_Click);
        }

        private void BtnLevel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            // Defensive Programming
            if (btn == null)
                return;

            Level level = btn.Tag as Level;

            // Defensive Programming
            if (level == null)
                return;

            GameManager.Instance.CurrentLevel = level.IdLevel;
            GameManager.Instance.AlurSaatIni = AlurGame.MODE_GAMBAR;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GameManager.Instance.AlurSaatIni =
                AlurGame.MENU_PILIH_MODE;
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}