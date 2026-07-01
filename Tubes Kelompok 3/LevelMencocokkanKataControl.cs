using System;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    internal partial class LevelMencocokkanKataControl : LevelBaseControl
    {
        public LevelMencocokkanKataControl()
        {
            InitializeComponent();

            LoadLevel();
        }

        private void LoadLevel()
        {
            LoadLevels(
                flowLevel,
                "MENCOCOKKAN_KATA",
                BtnLevel_Click);
        }

        private void BtnLevel_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            Level level = btn.Tag as Level;

            if (level == null)
                return;

            GameManager.Instance.CurrentLevel = level.IdLevel;
            GameManager.Instance.AlurSaatIni =
                AlurGame.MODE_MENCOCOKAN_KATA;
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