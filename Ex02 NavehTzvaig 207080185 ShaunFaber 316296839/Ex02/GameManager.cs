using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        private static readonly int sr_MaxPossibleTries = 10;
        private static readonly int sr_MinPossibleTries = 4;
        private static readonly string sr_QuitChar = "Q";
        private static int s_TotalNumberOfTries;
        private static int s_CurrentNumberOfTry = 1;
        private static bool s_WonTheGame = false;
        private static bool s_AnotherGame = false;
        private static bool s_ExitGame = false;
        private Code m_SecretCode;
        private GuessResult m_guessResult;
        private Board m_Board;

        internal bool WonTheGame
        {
            get { return s_WonTheGame; }
            set { s_WonTheGame = value; }
        }

        private void startOver()
        {
            m_SecretCode = new Code();    // Generate code
            m_guessResult = new GuessResult();
            s_TotalNumberOfTries = getAndValidateNumberOfTries();
            m_Board = new Board(s_TotalNumberOfTries);  // Initialize board
            s_CurrentNumberOfTry = 1;
            s_WonTheGame = false;
            s_AnotherGame = false;
            s_ExitGame = false;
        }

        public void StartGame()
        {
            /* Generate code    - CODE.CS - ♥
             * initialize board     - BOARD.CS - ♥
             * Ask the user how many tries he wants to have - CONSOLE_UI.CS - ♥
             * check the input - ♥
             * game loop -   GAME_MANAGER.CS     
             *      Get input from the user - CONSOLE_UI.CS - ♥
             *      Check if 'Q' was pressed - GAME_MANAGER - ♥
             *      check if it is valid - syntax - CONSOLE_UI.CS - ♥
             *      check if it is valid - logic - GAME_MANAGER.CS - ♥
             *      compare code and guess      - CODE.CS - ♥
             *      update the result in board - BOARD.CS - ♥
             *      Clear screen - dll - 
             *      print result on the board   - CONSOLE_UI.CS - ♥
             *      check if game over - GAME_MANAGER.CS - ♦
            */


            do
            {
                startOver();
                gameLoop(s_TotalNumberOfTries);
            }
            while(s_AnotherGame);
        }

        private void gameLoop(int i_TotalNumberOfTries)
        {
            while (!s_ExitGame)
            {
                string newGuessString = getAndValidateNewGuess();

                if (checkIfQuit(newGuessString) == true)
                {
                    s_ExitGame = true;
                    break;
                }

                Code newGuess = new Code(newGuessString);
                m_SecretCode.CompareGuessToCode(newGuess, m_guessResult);
                Code.SpacingPin(newGuess.CodeLetters);
                m_Board.UpdateBoard(newGuess, m_guessResult, s_CurrentNumberOfTry);
                ConsoleUI.PrintBoard(m_Board);

                newGuess = null;
                updateIfWin(m_guessResult);
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

        private static bool checkIfQuit(string i_inputToCheck)
        {
            bool quit = false;

            if (i_inputToCheck == sr_QuitChar)
            {
                quit = true;
            }

            return quit;
        }

        private static int getAndValidateNumberOfTries()
        {
            int numberOfTriesInt;
            bool validInput = false;

            do
            {
                string inputNumberOfTriesString = ConsoleUI.GetMaxTriesFromUser();
                validInput = int.TryParse(inputNumberOfTriesString, out numberOfTriesInt) && numberOfTriesInt <= sr_MaxPossibleTries && numberOfTriesInt >= sr_MinPossibleTries;

                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please a number between 4 to 10.");
                }
            }
            while (!validInput);

            return numberOfTriesInt;
        }

        private static string getAndValidateNewGuess()
        {
            string newGuessFromUser;
            bool validGuess = false;
            do
            {
                newGuessFromUser = ConsoleUI.GetNewGuess().ToUpper();

                validGuess = Code.CheckInputSyntax(newGuessFromUser) && 
                             Code.CheckIrrelevantInput(newGuessFromUser);

                if (!validGuess)
                {
                    Console.WriteLine("Invalid input. Please enter 4 different letters from A to H.");
                }
            } while (!validGuess);

            return newGuessFromUser;
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
                string playAgain = ConsoleUI.AnotherGame().ToUpper();

                switch (playAgain)
                {
                    case "Y":
                        ConsoleUI.ClearScreen();
                        validInput = true;
                        s_AnotherGame = true;
                        break;
                    case "N":
                        ConsoleUI.ClearScreen();
                        validInput = true;
                        s_AnotherGame = false;
                        break;
                    default:
                        ConsoleUI.PrintGenericMessage("Wrong Input");
                        validInput = false;
                        break;
                }
            }
            while (!validInput);
        }
    }
}
