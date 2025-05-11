using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    internal class Code
    {
        private readonly StringBuilder r_Code;
        private const int k_CodeLength = 4;

        public Code() // Constructor for the code that generates a random code
        {
            r_Code = generateCode();
        }
       
        public Code(string i_Code) // Constructor for the code that receives a code from the user
        {
            r_Code = new StringBuilder(i_Code);
        }

        private StringBuilder generateCode()
        {
            List<char> letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            StringBuilder code = new StringBuilder(k_CodeLength);

            Random randomNumber = new Random();
            
            for(int i = 0; i < k_CodeLength; i++)
            {
                int index = randomNumber.Next(letters.Count);
                code.Append(letters[index]);
                letters.RemoveAt(index);
            }

            return code;
        }

        internal void CompareGuessToCode(Code i_OtherCode)
        {
            GuessResult.NumOfV = 0;
            GuessResult.NumOfX = 0;

            for(int i = 0; i < k_CodeLength; i++)
            {
                int indexInCode = r_Code.ToString().IndexOf(i_OtherCode.ToString()[i]); // Initialize 'indexInCode' to have index of the 'i' letter of the guess
                
                // Compare indexes
                if(indexInCode == i)       // The code and the guess have the same letter in the same index
                {
                    GuessResult.NumOfV++;
                }
                else if(indexInCode != -1) // The code and the guess have the same letter in a different index
                {
                    GuessResult.NumOfV++;
                }
            }
        }
    }
}
