using System;
using System.Text;

namespace Ex02
{
    internal class Board
    {
        private const int k_FirstLinesOfChart = 2;
        private readonly int r_MaxRow;
        private readonly StringBuilder[] r_Board;

        public Board(int i_NumberOfGuesses)
        {
            r_MaxRow = 4 + 2 * i_NumberOfGuesses;
            r_Board = new StringBuilder[r_MaxRow];

            createBoard();
        }

        internal StringBuilder[] GetBoard
        {
            get { return r_Board; }
        }

        private void createBoard()
        {
            r_Board[0] = new StringBuilder("|Pins:    |Result:  |");
            r_Board[1] = new StringBuilder("|=========|=========|");
            r_Board[2] = new StringBuilder("| # # # # |         |");
            r_Board[3] = new StringBuilder("|=========|=========|");

            for (int i = 4; i < r_MaxRow; i+=2)
            {
                r_Board[i] = new StringBuilder("|         |         |");
                r_Board[i + 1] = new StringBuilder("|=========|=========|");
            }
        }

        internal void UpdateBoard(Code i_NewGuess, GuessResult i_GuessResult, int i_GuessNumber)
        {
            string guessString = i_NewGuess.CodeLetters.ToString();
            string resultString = i_GuessResult.GetResultString();
            int rowNumber = k_FirstLinesOfChart + 2 * i_GuessNumber;

            if (r_Board[rowNumber].Length >= guessString.Length)
            {
                r_Board[rowNumber].Remove(2, guessString.Length);
                r_Board[rowNumber].Insert(2, guessString);
            
                r_Board[rowNumber].Remove(12, resultString.Length);
                r_Board[rowNumber].Insert(12, resultString);
            }
        }

        internal void RevealSecretCodeOnBoard(StringBuilder i_SecretCode)
        {
            Code.SpacingPin(i_SecretCode);
            r_Board[2].Remove(2, i_SecretCode.Length);
            r_Board[2].Insert(2, i_SecretCode);
        }
    }

}
