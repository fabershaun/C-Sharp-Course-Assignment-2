using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GameForm : Form
    {
        private const int k_CodeLength = 4;
        private readonly int r_NumberOfTries;
        private readonly List<Button> r_SecretCodeUnits;
        private readonly List<GuessRow> r_GuessRows = new List<GuessRow>();
        private readonly GameLogic r_GameLogic = new GameLogic();
        private readonly Color r_BullColor = Color.Black;
        private readonly Color r_CowsColor  = Color.Yellow;

        public GameForm(int i_NumberOfTries)
        {
            r_GameLogic.GenerateCode();
            r_NumberOfTries = i_NumberOfTries;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            r_SecretCodeUnits = new List<Button> { button1, button2, button3, button4 };
            createAllLinesOfGuesses();
            enableGuessingForTheFirstLine();
        }

        private void enableGuessingForTheFirstLine()
        {
            r_GuessRows[0].EnableGuessing(true);
        }

        private void createAllLinesOfGuesses()
        {
            for(int i = 0; i < r_NumberOfTries; i++)
            {
                GuessRow guessRow = new GuessRow();
                guessRow.Top = 85 + i * guessRow.Height;
                guessRow.Left = 15;

                guessRow.GuessSubmitted += onGuessSubmitted;

                this.Controls.Add(guessRow);
                r_GuessRows.Add(guessRow);
            }
        }

        private void onGuessSubmitted(object sender, EventArgs e)
        {
            GuessRow currentRow = sender as GuessRow;
            int currentIndex = r_GuessRows.IndexOf(currentRow);

            r_GuessRows[currentIndex].EnableGuessing(false);

            bool isWonTheGame = r_GameLogic.CompareGuessToCode(currentRow.GuessButtonIndexes, out int numOfBulls, out int numOfCows);

            revealGuessResult(currentRow, numOfBulls, numOfCows);

            if(isWonTheGame || currentIndex + 1 == r_GuessRows.Count)
            {
                revealResultToTheUser();
            }
            else if (currentIndex + 1 < r_GuessRows.Count)
            {
                r_GuessRows[currentIndex + 1].EnableGuessing(true);
            }
        }

        private void revealResultToTheUser()
        {
            for(int i = 0; i < k_CodeLength; i++)
            {
                int index = r_GameLogic.CodeElements[i];
                r_SecretCodeUnits[i].BackColor = ColorPickForm.TotalColors[index];
            }
        }

        private void revealGuessResult(GuessRow i_CurrentRow, int i_NumOfBulls, int i_NumOfCows)
        {
            foreach (PictureBox resultGuessUnit in i_CurrentRow.ResultGuess)
            {
                if(i_NumOfBulls > 0)
                {
                    resultGuessUnit.BackColor = r_BullColor;
                    i_NumOfBulls--;
                }
                else if(i_NumOfCows > 0)
                {
                    resultGuessUnit.BackColor = r_CowsColor;
                    i_NumOfCows--;
                }
                else
                {
                    break;
                }
            }
        }
    }
}