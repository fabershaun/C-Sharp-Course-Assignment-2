using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class ConsoleUI
    {
        public ConsoleUI() { }

        internal static void PrintBoard(Board i_Board)
        {
            StringBuilder[] board = i_Board.GetBoard;

            foreach (StringBuilder line in board)
            {
                Console.WriteLine(line.ToString());
            }
        }

        internal static string GetNewGuess()
        {
            Console.WriteLine("Please type your next guess <ABCD> or 'Q' to quit");
            return Console.ReadLine();
        }
    }
}
