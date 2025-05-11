using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        private static readonly int sr_MaxTries = 10;
        private static readonly int sr_MinTries = 4;
        private static int s_NumberOfTries = ConsoleUI.GetMaxTriesFromUser(); // Think if here
        private static bool s_ExitGame = false;

        private readonly Code r_SecretCode = new Code();    // Generate code
        Board board = new Board();                          // Initialize board

        public void StartGame()
        {
            /*      Generate code    - CODE.CS - ☻
             *      initialize board     - BOARD.CS - ☺
             *      Ask the user how many tries he wants to have - CONSOLE_UI.CS - ☺
             * game loop -   GAME_MANAGER.CS     
             *      Get input from the user - CONSOLE_UI.CS
             *      check if it is valid - syntax - CONSOLE_UI.CS
             *      check if it is valid - logic - GAME_MANAGER.CS
             *      compare code and guess      - CODE.CS
             *      update the result in board - BOARD.CS
             *      print result on the board   - CONSOLE_UI.CS
             *      check if game over ('Q' was pressed) - GAME_MANAGER.CS
            */


            gameLoop();
        }

        private void gameLoop()
        {
            while(!s_ExitGame)
            {
                string newGuessString = ConsoleUI.GetNewGuess();    // Inside the method - check syntax and logic
                Code newGuess = new Code(newGuessString);
                r_SecretCode.CompareGuessToCode(newGuess);

            }
        }
    }
}
