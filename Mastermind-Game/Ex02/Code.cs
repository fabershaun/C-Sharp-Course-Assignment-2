using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class Code
    {
        private const int k_CodeLength = 4;
        private readonly List<int> r_CodeElements = new List<int>(k_CodeLength);
        
        public static int CodeLength => k_CodeLength;
        
        public List<int> CodeElements => r_CodeElements;

        /*        internal enum eGuessValidation
                {
                    Ok,
                    EmptyInput,
                    NotUppercase,
                    WrongLength,
                    DuplicateLetters,
                    IllegalCharacters,
                    OutOfRangeLetter
                }*/


        public Code(int i_RangeOfOptions) // Constructor for the code that generates a random code
        {
            if (i_RangeOfOptions < k_CodeLength)
            {
                throw new ArgumentException($"Range must be at least {k_CodeLength} to avoid duplicates.");
            }

            generateCode(i_RangeOfOptions);
        }

/*        public Code(string i_Code) // Constructor for the code that receives a code from the user
        {
            CodeLetters = new StringBuilder(i_Code);
        }*/


        private void generateCode(int i_RangeOfOptions)
        {
            Random randomNumber = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();
            int i = 0;

            while(i < k_CodeLength)
            {
                int index = randomNumber.Next(i_RangeOfOptions);

                if(!usedNumbers.Add(index)) // Ensure no duplicate numbers in the code
                {
                    continue;
                }

                r_CodeElements.Add(index);
                i++;
            }
        }


    }
}
