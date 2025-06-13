using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameLogic
    {
        private static readonly int sr_MaxPossibleTries = 10;
        private static readonly int sr_MinPossibleTries = 4;
        private int m_TotalNumberOfTries = sr_MinPossibleTries;
        private static bool s_WonTheGame = false;
        private Code m_SecretCode;
        private GuessResult m_GuessResult;
        

        public static int MinPossibleTries => sr_MinPossibleTries;

        public static int MaxPossibleTries => sr_MaxPossibleTries;

        public int TotalNumberOfTries => m_TotalNumberOfTries;

        public void SetNumberOfTries(int i_Tries)
        {
            m_TotalNumberOfTries = i_Tries;
        }

        public void StartGame()
        {
            initializeGame();
        }

        private void initializeGame()
        {
            ColorPickForm colorPickForm = new ColorPickForm();
            int size = colorPickForm.TotalColorsToChoose.Count;
            m_SecretCode = new Code(size);    
            m_GuessResult = new GuessResult();
            s_WonTheGame = false;
        }


        /*private void gameLoop(int i_TotalNumberOfTries)
        {

            string newGuessString = ConsoleUI.GetAndValidateNewGuess(ref s_ExitGame);  /// !! We can delete without add something else
            Code newGuess = new Code(newGuessString);


            m_SecretCode.CompareGuessToCode(newGuess, m_GuessResult);
            Code.SpacingPin(newGuess.CodeLetters);
            m_Board.UpdateBoard(newGuess, m_GuessResult, s_CurrentNumberOfTry);
            ConsoleUI.PrintBoard(m_Board);      /// !! We can delete without add something else
            updateIfWin(m_GuessResult);
            endOfRound();
            
        }*/

        public bool IsGameWon()
        {
            return s_WonTheGame;
        }

        public Code GetSecretCode()
        {
            return m_SecretCode;
        }

        private void updateIfWin(GuessResult i_GuessResult)
        {
            if (i_GuessResult.NumOfV == Code.CodeLength)
            {
                s_WonTheGame = true;
            }
        }

/*       private void endOfRound()
        {
            if (s_WonTheGame)
            {
                winGame();
            }
            else if (s_CurrentNumberOfTry == m_TotalNumberOfTries)
            {
                gameOver();
            }

            s_CurrentNumberOfTry++;
        }*/

/*        private void winGame()
        {
            m_Board.RevealSecretCodeOnBoard(m_SecretCode.CodeLetters);
            ConsoleUI.PrintBoard(m_Board);      /// !! We can delete without add something else
            ConsoleUI.WinGame(s_CurrentNumberOfTry);   /// !!!!!     
        }

        private void gameOver()
        {
            m_Board.RevealSecretCodeOnBoard(m_SecretCode.CodeLetters);
            ConsoleUI.PrintBoard(m_Board);    /// !! We can delete without add something else
            ConsoleUI.LostGame();           /// !!!!!           
        }*/
    }
}
