using System;
using System.Collections.Generic;
using System.Text;

namespace Ex02
{
    internal class SecretCode
    {
        private readonly StringBuilder r_Code = generateCode();
        private const int k_CodeLength = 4;

        private static StringBuilder generateCode()
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

        internal void CompareGuessToCode(string i_Guess, out int o_CountV, out int o_CountX)
        {
            o_CountV = 0;
            o_CountX = 0;

            for(int i = 0; i < k_CodeLength; i++)
            {
                int indexInCode = r_Code.ToString().IndexOf(i_Guess[i]); // Initialize 'indexInCode' to have index of the 'i' letter of the guess
                
                // Compare indexes
                if(indexInCode == i)       // The code and the guess have the same letter in the same index
                {
                    o_CountV++;
                }
                else if(indexInCode != -1) // The code and the guess have the same letter in a different index
                {
                    o_CountX++;
                }
            }
        }
    }
}
