using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        public static void StartGame()
        {
            /* Generate code    - CODE.CS
             * initialize board     - BOARD.CS
             * Ask the user how many tries he wants to have - CONSOLE_UI.CS
             * game loop -   GAME_MANAGER.CS     
             *      Get input from the user - CONSOLE_UI.CS
             *      check if it is valid - syntax - CONSOLE_UI.CS
             *      check if it is valid - logic - GAME_MANAGER.CS
             *      compare code and guess      - CODE.CS
             *      update the result in board - BOARD.CS
             *      print result on the board   - CONSOLE_UI.CS
             *      check if game over  - GAME_MANAGER.CS
            */

            Code code = new Code();
            Board board = new Board();
            int maxTries = ConsoleUI.GetMaxTriesFromUser();

        }
    }
}
