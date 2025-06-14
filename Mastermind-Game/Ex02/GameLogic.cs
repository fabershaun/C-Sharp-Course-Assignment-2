using System;
using System.Collections.Generic;

namespace Ex02
{
    internal class GameLogic
    {
        private const int k_CodeLength = 4;
        private const int k_RangeOfOptions = 8;
        private const int k_MinPossibleTries = 4;
        private const int k_MaxPossibleTries = 10;
        //private int m_TotalNumberOfTries = k_MinPossibleTries;
        //private static bool s_WonTheGame = false;   // ??
        //private Code m_SecretCode;
        //private GuessResult m_GuessResult;  //??
        private readonly List<int> r_CodeElements = new List<int>(k_CodeLength);

        public static int CodeLength => k_CodeLength;

        public List<int> CodeElements => r_CodeElements;

        public static int RangeOfOptions => k_RangeOfOptions;

        public static int MinPossibleTries => k_MinPossibleTries;

        public static int MaxPossibleTries => k_MaxPossibleTries;

/*        public int TotalNumberOfTries => m_TotalNumberOfTries;

        public void SetNumberOfTries(int i_Tries)
        {
            m_TotalNumberOfTries = i_Tries;
        }
        */

/*        public void StartGame()
        {
            generateCode();
            initializeGame();
        }*/

        public void InitializeGame()
        {
            generateCode();
            //m_GuessResult = new GuessResult();
        }

        private void generateCode()
        {
            Random randomNumber = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();
            int i = 0;

            while (i < k_CodeLength)
            {
                int index = randomNumber.Next(k_RangeOfOptions);

                if (!usedNumbers.Add(index)) // Ensure no duplicate numbers in the code
                {
                    continue;
                }

                r_CodeElements.Add(index);
                i++;
            }
        }

        internal bool CompareGuessToCode(List<int> i_OtherCode, out int o_NumOfBulls, out int o_NumOfCows)
        {
            o_NumOfBulls = 0;
            o_NumOfCows = 0;

            for (int i = 0; i < k_CodeLength; i++)
            {
                int guessElement = i_OtherCode[i];

                if (guessElement == r_CodeElements[i])
                {
                    o_NumOfBulls++;
                }
                else if (r_CodeElements.Contains(guessElement))
                {
                    o_NumOfCows++;
                }
            }

            return o_NumOfBulls == CodeLength;
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
