using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class Code
    {
        private static readonly List<char> r_Letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };

        private const int k_CodeLength = 4;

        public Code() // Constructor for the code that generates a random code
        {
            CodeLetters = generateCode();
        }

        public Code(string i_Code) // Constructor for the code that receives a code from the user
        {
            CodeLetters = new StringBuilder(i_Code);
        }

        internal List<char> Letters
        {
            get { return r_Letters; }
        }

        internal StringBuilder CodeLetters { get; }

        private StringBuilder generateCode()
        {
            StringBuilder code = new StringBuilder(k_CodeLength);

            Random randomNumber = new Random();

            for (int i = 0; i < k_CodeLength; i++)
            {
                int index = randomNumber.Next(r_Letters.Count);
                code.Append(r_Letters[index]);
                r_Letters.RemoveAt(index);
            }

            return code;
        }

        internal void CompareGuessToCode(Code i_OtherCode, GuessResult io_GuessResult)
        {
            io_GuessResult.NumOfV = 0;
            io_GuessResult.NumOfX = 0;

            for (int i = 0; i < k_CodeLength; i++)
            {
                int indexInCode =
                    CodeLetters.ToString()
                        .IndexOf(
                            i_OtherCode.ToString()
                                [i]); // Initialize 'indexInCode' to have index of the 'i' letter of the guess

                // Compare indexes
                if (indexInCode == i) // The code and the guess have the same letter in the same index
                {
                    io_GuessResult.NumOfV++;
                }
                else if (indexInCode != -1) // The code and the guess have the same letter in a different index
                {
                    io_GuessResult.NumOfV++;
                }
            }
        }

        internal static bool CheckInputSyntax(string i_GuessString)
        {
            bool validInput = true;

            foreach(char letter in i_GuessString)
            {
                if(letter < 'A' || letter > 'Z')
                {
                    validInput = false;
                    break;
                }
            }

            return validInput;
        }

        internal static bool CheckIrrelevantInput(string i_GuessString)
        {
            bool validInput = true;

            foreach (char letter in i_GuessString)
            {
                if(!r_Letters.Contains(letter) && letter != 'Q')
                {
                    validInput = false;
                    break;
                }
            }

            return validInput;
        }
    }

}
