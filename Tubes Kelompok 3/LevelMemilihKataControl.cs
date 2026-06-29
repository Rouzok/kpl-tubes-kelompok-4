using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    public partial class LevelMemilihKataControl : UserControl
    {
        private readonly DatabaseSingleton database;

        public LevelMemilihKataControl()
        {
            InitializeComponent();

            database = DatabaseSingleton.GetInstance();

            LoadLevel();
        }

        private void LoadLevel()
        {
            flowLevel.Controls.Clear();

            List<Level> daftarLevel =
                database.GetLevels("MEMILIH_KATA");

            foreach (Level level in daftarLevel)
            {
                Button btnLevel = new Button();

                btnLevel.Width = 320;
                btnLevel.Height = 55;

                btnLevel.Margin = new Padding(10);

                btnLevel.FlatStyle = FlatStyle.Flat;
                btnLevel.FlatAppearance.BorderSize = 0;

                btnLevel.Font =
                    new Font("Segoe UI", 12, FontStyle.Bold);

                btnLevel.BackColor =
                    Color.FromArgb(214, 177, 116);

                btnLevel.ForeColor = Color.White;

                btnLevel.Tag = level;

                if (level.IsActive)
                {
                    btnLevel.Text = "Level " + level.LevelNumber;
                    btnLevel.Click += BtnLevel_Click;
                }
                else
                {
                    btnLevel.Text = "🔒 Level " + level.LevelNumber;
                    btnLevel.Enabled = false;
                    btnLevel.BackColor = Color.Gray;
                }

                flowLevel.Controls.Add(btnLevel);
            }
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
                AlurGame.MODE_MEMILIH_KATA;
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