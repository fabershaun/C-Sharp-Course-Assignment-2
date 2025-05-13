using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Board
    {
        private readonly int r_NumberOfGuesses;
        private readonly int r_MaxRow;
        private readonly StringBuilder[] s_Board;

        public Board(int i_NumberOfGuesses)
        {
            r_NumberOfGuesses = i_NumberOfGuesses;
            r_MaxRow = 4 + 2 * r_NumberOfGuesses;
            s_Board = new StringBuilder[r_MaxRow];

            createBoard();
        }

        internal StringBuilder[] GetBoard
        {
            get { return s_Board; }
        }

        private void createBoard()
        {
            s_Board[0] = new StringBuilder("|Pins:    |Result:|");
            s_Board[1] = new StringBuilder("|=========|=======|");
            s_Board[2] = new StringBuilder("| # # # # |       |");
            s_Board[3] = new StringBuilder("|=========|=======|");

            for (int i = 4; i < r_MaxRow; i+=2)
            {
                s_Board[i] = new StringBuilder("|         |       |");
                s_Board[i + 1] = new StringBuilder("|=========|=======|");
            }
        }

        internal void UpdateBoard(Code i_NewGuess, GuessResult i_GuessResult, int i_GuessNumber)
        {
            string guessString = i_NewGuess.CodeLetters.ToString();
            string resultString = i_GuessResult.GetResultString();
            int rowNumber = 2 + 2 * i_GuessNumber;

            if (s_Board[rowNumber].Length >= guessString.Length)
            {
                s_Board[rowNumber].Remove(2, guessString.Length);
                s_Board[rowNumber].Insert(2, guessString);
            
                s_Board[rowNumber].Remove(12, resultString.Length);
                s_Board[rowNumber].Insert(12, resultString);
            }
        }

        internal void RevealSecretCodeOnBoard(StringBuilder i_SecretCode)
        {
            Code.SpacingPin(i_SecretCode);

            s_Board[2].Remove(2, i_SecretCode.Length);
            s_Board[2].Insert(2, i_SecretCode);
        }
    }

}
