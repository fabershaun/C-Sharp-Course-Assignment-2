using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class ConsoleUI
    {
        private static readonly string sr_NewGameMessage = "Would you like to start a new game? (Y/N)";

        internal static string NewGameMessage
        {
            get { return sr_NewGameMessage; }
        }

        internal static void PrintBoard(Board i_Board)
        {
            StringBuilder[] board = i_Board.GetBoard;

            ClearScreen();
            Console.WriteLine("Current board status:");
            Console.WriteLine();

            foreach (StringBuilder line in board)
            {
                Console.WriteLine(line.ToString());
            }
        }

        internal static void ClearScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
        }

        internal static string GetNewGuess()
        {
            Console.WriteLine("Please type your next guess <ABCD> or 'Q' to quit:");
            return Console.ReadLine();
        }

        internal static string GetMaxTriesFromUser()
        {
            Console.WriteLine("Please type the number of guess in this game:");
            return Console.ReadLine();
        }

        internal static void WinGame(int i_CurrentNumberOfTry)
        {
            StringBuilder winMessage = new StringBuilder();

            winMessage.Append("You guessed after ");
            winMessage.Append(i_CurrentNumberOfTry);
            winMessage.AppendLine(" steps!");
        }

        internal static void LostGame()
        {
            Console.WriteLine("No more guesses allowed. You lost.");
        }

        internal static string AnotherGame()
        {
            Console.WriteLine(sr_NewGameMessage);
            return Console.ReadLine();
        }
        internal static void PrintGenericMessage(string i_Message)
        {
            Console.WriteLine(i_Message);
        }
    }
}
