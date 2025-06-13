using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex02
{
    public partial class GameForm : Form
    {
        private readonly int r_CodeLength = 4;
        private readonly int r_NumberOfTries;
        private readonly List<PictureBox> r_SecretCodeUnits = new List<PictureBox>();
        private readonly List<GuessRow> r_GuessRows = new List<GuessRow>();

        public GameForm(int i_NumberOfTries)
        {
            r_NumberOfTries = i_NumberOfTries;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            initializeSecretCodeBoxes();
            createAllLinesOfGuesses();
            enableGuessing();
        }

        private void initializeSecretCodeBoxes()
        {
            r_SecretCodeUnits.Add(pictureBox1);
            r_SecretCodeUnits.Add(pictureBox2);
            r_SecretCodeUnits.Add(pictureBox3);
            r_SecretCodeUnits.Add(pictureBox4);

            foreach (PictureBox pb in r_SecretCodeUnits)
            {
                pb.BackColor = Color.Black;
            }
        }

        private void enableGuessing()
        {
            r_GuessRows[0].EnableGuessing(true);
        }

        private void createAllLinesOfGuesses()
        {
            for(int i = 0; i < r_NumberOfTries; i++)
            {
                GuessRow guessRow = new GuessRow();
                guessRow.Top = 100 + i * guessRow.Height;
                guessRow.Left = 15;

                guessRow.GuessSubmitted += onGuessSubmitted;

                this.Controls.Add(guessRow);
                r_GuessRows.Add(guessRow);
            }
        }

        private void onGuessSubmitted(object i_Sender, EventArgs i_E)
        {
            GuessRow currentRow = i_Sender as GuessRow;

            int currentIndex = r_GuessRows.IndexOf(currentRow);

            if(currentIndex + 1 < r_GuessRows.Count)
            {
                r_GuessRows[currentIndex + 1].EnableGuessing(true);
            }
        }
    }
}
