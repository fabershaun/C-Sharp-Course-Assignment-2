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
        private List<PictureBox> m_SecretCodeUnits;
        private readonly List<GuessRow> r_GuessRows = new List<GuessRow>();
        private GameLogic m_GameLogic = new GameLogic();
        private Color k_BullColor = Color.Black;
        private Color k_CowsColor  = Color.Yellow;

        public GameForm(int i_NumberOfTries)
        {
            m_GameLogic.InitializeGame();
            r_NumberOfTries = i_NumberOfTries;

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            initializeSecretCodeBoxes();        // CHANGE NAME
            createAllLinesOfGuesses();
            enableGuessingForTheFirstLine();
        }

        private void initializeSecretCodeBoxes()
        {
            m_SecretCodeUnits = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

            foreach (PictureBox pb in m_SecretCodeUnits)
            {
                pb.BackColor = Color.Black;
            }
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
            bool isWonTheGame;
            GuessRow currentRow = sender as GuessRow;
            int currentIndex = r_GuessRows.IndexOf(currentRow);
            int numOfBulls, numOfCows;

            r_GuessRows[currentIndex].EnableGuessing(false);

            isWonTheGame = m_GameLogic.CompareGuessToCode(currentRow.GuessButtonIndexes, out numOfBulls, out numOfCows);

            RevealGuessResult(currentRow, numOfBulls, numOfCows);
            if(isWonTheGame || currentIndex + 1 == r_GuessRows.Count)
            {
                RevealResultToTheUser();
            }
            else if (currentIndex + 1 < r_GuessRows.Count)
            {
                r_GuessRows[currentIndex + 1].EnableGuessing(true);
            }
        }

        private void RevealResultToTheUser()
        {
            for(int i = 0; i < r_CodeLength; i++)
            {
                int index = m_GameLogic.CodeElements[i]; // Assuming SecretCode is a List<Color>
                m_SecretCodeUnits[i].BackColor = ColorPickForm.TotalColors[index];
            }
        }

        private void RevealGuessResult(GuessRow currentRow, int i_numOfBulls, int i_numOfCows)
        {
            foreach (PictureBox resultGuessUnit in currentRow.ResultGuess)
            {
                if(i_numOfBulls > 0)
                {
                    resultGuessUnit.BackColor = k_BullColor;
                    i_numOfBulls--;
                }
                else if(i_numOfCows > 0)
                {
                    resultGuessUnit.BackColor = k_CowsColor;
                    i_numOfCows--;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
