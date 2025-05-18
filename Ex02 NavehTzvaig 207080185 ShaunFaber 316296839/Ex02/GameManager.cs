using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameManager
    {
        private const int k_MaxPossibleTries = 10;
        private const int k_MinPossibleTries = 4;
        private static int s_TotalNumberOfTries;
        private static int s_CurrentNumberOfTry = 1;
        private static bool s_WonTheGame = false;
        private static bool s_AnotherGame = false;
        private static bool s_ExitGame = false;
        private Code m_SecretCode;
        private GuessResult m_GuessResult;
        private Board m_Board;

        public void StartGame()
        {
            do
            {
                startOver();
                gameLoop(s_TotalNumberOfTries);
            }
            while (s_AnotherGame);
        }

        private void startOver()
        {
            m_SecretCode = new Code();    // Generate code
            m_GuessResult = new GuessResult();
            s_TotalNumberOfTries = ConsoleUI.GetAndValidateNumberOfTries(k_MinPossibleTries, k_MaxPossibleTries);
            m_Board = new Board(s_TotalNumberOfTries);  // Initialize board
            ConsoleUI.PrintBoard(m_Board);
            s_CurrentNumberOfTry = 1;
            s_WonTheGame = false;
            s_AnotherGame = false;
            s_ExitGame = false;
        }

        private void gameLoop(int i_TotalNumberOfTries)
        {
            while (!s_ExitGame)
            {
                string newGuessString = ConsoleUI.GetAndValidateNewGuess(ref s_ExitGame);
                Code newGuess = new Code(newGuessString);

                if (s_ExitGame)
                {
                    break;
                }

                m_SecretCode.CompareGuessToCode(newGuess, m_GuessResult);
                Code.SpacingPin(newGuess.CodeLetters);
                m_Board.UpdateBoard(newGuess, m_GuessResult, s_CurrentNumberOfTry);
                ConsoleUI.PrintBoard(m_Board);
                updateIfWin(m_GuessResult);
                endOfRound();
            }
        }

        private void updateIfWin(GuessResult i_GuessResult)
        {
            if (i_GuessResult.NumOfV == Code.CodeLength)
            {
                s_WonTheGame = true;
            }
        }

       private void endOfRound()
        {
            if (s_WonTheGame)
            {
                winGame();
            }
            else if (s_CurrentNumberOfTry == s_TotalNumberOfTries)
            {
                gameOver();
            }

            s_CurrentNumberOfTry++;
        }

        private void winGame()
        {
            s_ExitGame = true;
            m_Board.RevealSecretCodeOnBoard(m_SecretCode.CodeLetters);
            ConsoleUI.PrintBoard(m_Board);
            ConsoleUI.WinGame(s_CurrentNumberOfTry);
            playAgain();
        }

        private void gameOver()
        {
            s_ExitGame = true;
            m_Board.RevealSecretCodeOnBoard(m_SecretCode.CodeLetters);
            ConsoleUI.PrintBoard(m_Board);
            ConsoleUI.LostGame();
            playAgain();
        }

        private void playAgain()
        {
            bool validInput = false;

            do
            {
                ConsoleUI.AnotherGame(ref validInput, ref s_AnotherGame);
            }
            while (!validInput);
        }
    }
}
