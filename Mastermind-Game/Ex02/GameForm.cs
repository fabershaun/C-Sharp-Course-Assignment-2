using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex02
{
    internal class GameForm : Form
    {
        public GameForm()
        {
            initializeComponents();
        }

        private void initializeComponents()
        {
            this.Text = "Mastermind Game";
            this.BackColor = Color.LavenderBlush;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            Button buttonExit = new Button();
            buttonExit.Text = "Exit";
            buttonExit.AutoSize = true;
            buttonExit.Top = this.Bottom - (buttonExit.Height + 50);
            buttonExit.Left = this.ClientSize.Width - (buttonExit.Width + 15);
            //buttonExit.Click += new EventHandler(buttonExit_Click);
            this.Controls.Add(buttonExit);
        }
    }
}
