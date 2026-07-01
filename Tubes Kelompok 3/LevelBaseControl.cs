using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Tubes_Kelompok_3
{
    internal partial class LevelBaseControl : UserControl
    {
        protected readonly DatabaseSingleton database;

        public LevelBaseControl()
        {
            InitializeComponent();

            database = DatabaseSingleton.GetInstance();

            //Postcondition
            Debug.Assert(database != null,
                "DatabaseSingleton gagal dibuat.");
        }

        protected void LoadLevels(
            FlowLayoutPanel flowLevel,
            string mode,
            EventHandler clickEvent)
        {
            //Precondition
            if (flowLevel == null)
                throw new ArgumentNullException(nameof(flowLevel));

            if (string.IsNullOrWhiteSpace(mode))
                throw new ArgumentException("Mode tidak boleh kosong.");

            if (clickEvent == null)
                throw new ArgumentNullException(nameof(clickEvent));

            flowLevel.Controls.Clear();

            List<Level> daftarLevel = database.GetLevels(mode);

            foreach (Level level in daftarLevel)
            {
                Button btn = new Button();

                btn.Width = 320;
                btn.Height = 55;
                btn.Margin = new Padding(10);

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                btn.Font = new Font(
                    "Segoe UI",
                    12,
                    FontStyle.Bold);

                btn.BackColor = Color.FromArgb(214, 177, 116);
                btn.ForeColor = Color.White;

                btn.Tag = level;

                if (level.IsActive)
                {
                    btn.Text = "Level " + level.LevelNumber;
                    btn.Click += clickEvent;
                }
                else
                {
                    btn.Text = "🔒 Level " + level.LevelNumber;
                    btn.Enabled = false;
                    btn.BackColor = Color.Gray;
                }

                flowLevel.Controls.Add(btn);
            }

            // Postcondition
            Debug.Assert(
                flowLevel.Controls.Count == daftarLevel.Count,
                "Jumlah tombol level tidak sesuai.");
        }
    }
}