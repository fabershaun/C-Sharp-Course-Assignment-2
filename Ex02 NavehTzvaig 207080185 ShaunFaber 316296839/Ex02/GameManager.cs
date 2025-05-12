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
        private static int s_TotalNumberOfTries = ConsoleUI.GetMaxTriesFromUser(); // Think if here
        private static readonly string sr_QuitChar = "Q";
        private static int s_CurrentNumberOfTry = 0;
        private static bool s_ExitGame = false;
        private static bool s_WonTheGame = false;
        private readonly Code r_SecretCode = new Code();    // Generate code
        private Board m_board = new Board(s_NumberOfTries);                          // Initialize board

        internal bool WonTheGame
        {
            get { return s_WonTheGame; }
            set { s_WonTheGame = value; }
        }



        public void StartGame()
        {
            /*      Generate code    - CODE.CS - ♥
             *      initialize board     - BOARD.CS - ♥
             *      Ask the user how many tries he wants to have - CONSOLE_UI.CS - ♦
             *      check the input - ♦
             * game loop -   GAME_MANAGER.CS     
             *      Get input from the user - CONSOLE_UI.CS - ♥
             *      Check if 'Q' was pressed - GAME_MANAGER - ♥
             *      check if it is valid - syntax - CONSOLE_UI.CS - ♥
             *      check if it is valid - logic - GAME_MANAGER.CS - ♥
             *      compare code and guess      - CODE.CS - ♥
             *      update the result in board - BOARD.CS - ♥
             *      print result on the board   - CONSOLE_UI.CS - ♥
             *      check if game over - GAME_MANAGER.CS - ♦
            */


            gameLoop();
        }

        private void gameLoop()
        {

            while (!s_ExitGame)
            {
                string newGuessString = ConsoleUI.GetNewGuess();
                HandleGuessString(newGuessString); // TODO


                if (checkIfQuit(newGuessString) == true)
                {
                    s_ExitGame = true;
                    break;
                }

                Code newGuess = new Code(newGuessString);

                
                GuessResult guessResult = new GuessResult();

                r_SecretCode.CompareGuessToCode(newGuess, guessResult);
                m_board.UpdateBoard(newGuess, guessResult, s_TotalNumberOfTries); //TODO
                ConsoleUI.PrintBoard(m_board); 

                endOfRound();
            }
        }

        private bool checkIfQuit(string i_inputToCheck)
        {
            bool quit = false;

            if (i_inputToCheck == sr_QuitChar)
            {
                quit = true;
            }

            return quit;
        }

        private void HandleGuessString(string io_GuessString)
        {
            bool validGuess = false;

            while(!validGuess)
            {
                io_GuessString = io_GuessString.ToUpper();

                validGuess = Code.CheckInputSyntax(io_GuessString);

                if(validGuess)
                {
                    validGuess = Code.CheckIrrelevantInput(io_GuessString);
                }
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
        }

        private void winGame()
        {
        }

        private void gameOver()
        {
        }
    }
}
