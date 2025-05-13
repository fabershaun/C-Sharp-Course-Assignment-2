using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex02
{
    internal class Code
    {
        private static readonly char[] sr_OptionsLetters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private const int k_CodeLength = 4;
        private List<char> m_PinLetter;
        private StringBuilder m_CodeLetters;

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
            get { return m_PinLetter; }
        }

        internal static int CodeLength
        {
            get { return k_CodeLength; }
        }

        internal StringBuilder CodeLetters
        {
            get { return m_CodeLetters; }
            set { m_CodeLetters = value; }
        }

        private StringBuilder generateCode()
        {
            StringBuilder code = new StringBuilder(k_CodeLength);
            m_PinLetter = new List<char>(sr_OptionsLetters);
            Random randomNumber = new Random();

            for (int i = 0; i < k_CodeLength; i++)
            {
                int index = randomNumber.Next(m_PinLetter.Count);
                code.Append(m_PinLetter[index]);
                m_PinLetter.RemoveAt(index);
            }

            return code;
        }

        internal void CompareGuessToCode(Code i_OtherCode, GuessResult io_GuessResult)
        {
            io_GuessResult.NumOfV = 0;
            io_GuessResult.NumOfX = 0;

            for (int i = 0; i < k_CodeLength; i++)
            {
                char guessChar = i_OtherCode.CodeLetters[i];
                int indexInCode = CodeLetters.ToString().IndexOf(guessChar); // Initialize 'indexInCode' to have index of the 'i' letter of the guess

                // Compare indexes
                if (indexInCode == i) // The code and the guess have the same letter in the same index
                {
                    io_GuessResult.NumOfV++;
                }
                else if (indexInCode != -1) // The code and the guess have the same letter in a different index
                {
                    io_GuessResult.NumOfX++;
                }
            }
        }

        internal static bool CheckInputSyntax(string i_GuessString)
        {
            bool validInput = true;

            foreach(char letter in i_GuessString)
            {
                if(!(sr_OptionsLetters.Contains(letter)) && letter != 'Q')
                {
                    validInput = false;
                    break;
                }
            }

            return validInput;
        }

        internal static bool CheckIrrelevantInput(string i_GuessString)
        {
            return isLengthValid(i_GuessString) && !hasDuplicateLetters(i_GuessString);
        }

        private static bool isLengthValid(string i_GuessString)
        {
            return i_GuessString.Length == k_CodeLength || i_GuessString == "Q";
        }

        private static bool hasDuplicateLetters(string i_GuessString)
        {
            return new HashSet<char>(i_GuessString).Count != i_GuessString.Length;  
        }

        internal static void SpacingPin(StringBuilder i_Pin)
        {
            StringBuilder spaced = new StringBuilder();

            for (int i = 0; i < i_Pin.Length; i++)
            {
                spaced.Append(i_Pin[i]);
                if (i < i_Pin.Length - 1)
                    spaced.Append(' ');
            }

            i_Pin.Clear();
            i_Pin.Append(spaced);
        }
    }

}
