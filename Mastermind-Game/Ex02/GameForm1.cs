using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex02
{
    internal class GameForm1 : Form
    {
        private readonly List<PictureBox> r_SecretCodeUnits = new List<PictureBox>(Code.CodeLength);
        private readonly List<GuessRow1> r_GuessRows = new List<GuessRow1>(Code.CodeLength);
        private readonly int r_NumberOfTries;
        private readonly int r_CodeLength;

        public GameForm1(int i_NumberOfTries, int i_CodeLength)
        {
            r_NumberOfTries = i_NumberOfTries;
            r_CodeLength = i_CodeLength;

            this.Text = "Mastermind Game";
            this.BackColor = Color.LavenderBlush;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;

            initializeComponents();
        }

        private void initializeComponents()
        {
            createSecretCodeLine();
            createAllLinesOfGuesses(r_NumberOfTries);
        }

        private void createSecretCodeLine()
        {
            for(int i = 0; i < Code.CodeLength; i++)
            {
                PictureBox secretCodeUnit = new PictureBox();
                secretCodeUnit.BackColor = Color.Black;
                secretCodeUnit.Size = new Size(45, 45);
                secretCodeUnit.Top = 15;

                if(i > 0)
                {
                    secretCodeUnit.Left = r_SecretCodeUnits[i - 1].Right + 5;
                }
                else
                {
                    secretCodeUnit.Left = 15;
                }

                r_SecretCodeUnits.Add(secretCodeUnit);
                this.Controls.Add(secretCodeUnit);
            }
        }

        private void createAllLinesOfGuesses(int i_TotalNumberOfTries)
        {
            for(int i = 0; i < i_TotalNumberOfTries; i++)
            {
                GuessRow1 guessRow = new GuessRow1(i, r_SecretCodeUnits[0].Bottom + 20, r_CodeLength);

                guessRow.ColorButtonClicked += onColorButtonClicked;

                guessRow.AddToForm(this);
                r_GuessRows.Add(guessRow);
            }
        }

        private void onColorButtonClicked(object sender, Button button)
        {
            using (ColorsForm colorForm = new ColorsForm())
            {
                if (colorForm.ShowDialog() == DialogResult.OK)
                {
                    button.BackColor = colorForm.SelectedColor;
                }
            }
        }


    }
}
