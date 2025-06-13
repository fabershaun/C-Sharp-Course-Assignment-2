using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex02
{
    internal class StartForm1 : Form
    {
        private int m_TotalNumberOfTries;

        public StartForm1()
        {
            m_TotalNumberOfTries = GameLogic.MinPossibleTries;

            this.Text = "Mastermind Game";
            this.BackColor = Color.LavenderBlush;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(300, 150);
            this.StartPosition = FormStartPosition.CenterScreen;

            initializeComponents();
        }
        public int TotalNumberOfTries => m_TotalNumberOfTries;

        private void initializeComponents()
        {
            Button buttonStart = new Button();
            buttonStart.Text = "Start";
            buttonStart.AutoSize = true;
            buttonStart.Top = this.Bottom - (buttonStart.Height + 50);
            buttonStart.Left = this.ClientSize.Width - (buttonStart.Width + 15);
            buttonStart.Click += new EventHandler(buttonStart_Click);
            this.Controls.Add(buttonStart);

            Button buttonNumberOfChances = new Button();
            buttonNumberOfChances.Text = $"Number of chances: {GameLogic.MinPossibleTries}";
            buttonNumberOfChances.Top = 15;
            buttonNumberOfChances.Left = 15;
            buttonNumberOfChances.Width = this.ClientSize.Width - 30;
            buttonNumberOfChances.Click += new EventHandler(buttonNumberOfChances_Click);
            this.Controls.Add(buttonNumberOfChances);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            //OnNumberOfTriesRequested();
            m_TotalNumberOfTries++;

            if (m_TotalNumberOfTries > GameLogic.MaxPossibleTries)
            {
                m_TotalNumberOfTries = GameLogic.MinPossibleTries;
            }

            (sender as Button).Text = $"Number of chances: {m_TotalNumberOfTries}";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // StartForm1
            // 
            this.ClientSize = new System.Drawing.Size(1440, 975);
            this.Name = "StartForm1";
            this.ResumeLayout(false);

        }


    }
}
