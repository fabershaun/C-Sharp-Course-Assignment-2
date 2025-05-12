using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Board
    {
        private readonly int s_NumberOfGuesses;
        private readonly int s_MaxRow;
        private readonly StringBuilder[] s_Board;

        public Board(int i_NumberOfGuesses)
        {
            s_NumberOfGuesses = i_NumberOfGuesses;
            s_MaxRow = 4 + 2 * s_NumberOfGuesses;
            s_Board = new StringBuilder[s_MaxRow];

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
            s_Board[2] = new StringBuilder("| # # # # |        |");
            s_Board[3] = new StringBuilder("|=========|=======|");

            for (int i = 2; i < s_MaxRow; i+=2)
            {
                s_Board[i] = new StringBuilder("|         |        |");
                s_Board[i + 1] = new StringBuilder("|=========|=======|");
            }
        }

        internal void UpdateBoard(Code i_NewGuess, GuessResult i_GuessResult, int i_GuessNumber)
        {
            string guessString = i_NewGuess.CodeLetters.ToString();
            string resultString = i_GuessResult.GetResult();
            int rowNumber = 4 + 2 * i_GuessNumber;

            s_Board[rowNumber].Insert(2, guessString);
            s_Board[rowNumber].Insert(12, resultString);
        }
    }

}
