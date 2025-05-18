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

        internal enum eGuessValidation
        {
            Ok,
            EmptyInput,
            NotUppercase,
            WrongLength,
            DuplicateLetters,
            IllegalCharacters,
            OutOfRangeLetter
        }

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
            get
            {
                return m_PinLetter;
            }
        }

        internal static int CodeLength
        {
            get
            {
                return k_CodeLength;
            }
        }

        internal StringBuilder CodeLetters
        {
            get
            {
                return m_CodeLetters;
            }
            set
            {
                m_CodeLetters = value;
            }
        }

        private StringBuilder generateCode()
        {
            StringBuilder code = new StringBuilder(k_CodeLength);
            m_PinLetter = new List<char>(sr_OptionsLetters);
            Random randomNumber = new Random();

            for(int i = 0; i < k_CodeLength; i++)
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

            for(int i = 0; i < k_CodeLength; i++)
            {
                char guessChar = i_OtherCode.CodeLetters[i];
                int indexInCode =
                    CodeLetters.ToString()
                        .IndexOf(guessChar); // Initialize 'indexInCode' to have index of the 'i' letter of the guess

                // Compare indexes
                if(indexInCode == i) // The code and the guess have the same letter in the same index
                {
                    io_GuessResult.NumOfV++;
                }
                else if(indexInCode != -1) // The code and the guess have the same letter in a different index
                {
                    io_GuessResult.NumOfX++;
                }
            }
        }

        internal static eGuessValidation CheckInputGuessSyntax(string i_GuessString)
        {
            eGuessValidation result = eGuessValidation.Ok;

            if(string.IsNullOrEmpty(i_GuessString))
            {
                result = eGuessValidation.EmptyInput;
            }
            else
            {
                foreach(char letter in i_GuessString)
                {
                    if(!char.IsLetter(letter) && letter != ConsoleUI.QuitChar)
                    {
                        result = eGuessValidation.IllegalCharacters;
                        break;
                    }
                }
            }

            return result;
        }

        internal static eGuessValidation CheckIrrelevantGuessInput(string i_GuessString)
        {
            eGuessValidation result = eGuessValidation.Ok;

            if(i_GuessString != ConsoleUI.QuitChar.ToString())
            {
                if(i_GuessString.Any(char.IsLower))
                {
                    result = eGuessValidation.NotUppercase;
                }
                else if(!isLengthValid(i_GuessString))
                {
                    result = eGuessValidation.WrongLength;
                }
                else if(hasDuplicateLetters(i_GuessString))
                {
                    result = eGuessValidation.DuplicateLetters;
                }
                else
                {
                    foreach(char letter in i_GuessString)
                    {
                        if(!sr_OptionsLetters.Contains(letter))
                        {
                            result = eGuessValidation.OutOfRangeLetter;
                            break;
                        }
                    }
                }
            }

            return result;
        }

        private static bool isLengthValid(string i_GuessString)
        {
            return i_GuessString.Length == k_CodeLength || i_GuessString == ConsoleUI.QuitChar.ToString();
        }

        private static bool hasDuplicateLetters(string i_GuessString)
        {
            return new HashSet<char>(i_GuessString).Count != i_GuessString.Length;
        }

        internal static void SpacingPin(StringBuilder i_Pin)
        {
            StringBuilder spaced = new StringBuilder();

            for(int i = 0; i < i_Pin.Length; i++)
            {
                spaced.Append(i_Pin[i]);
                if(i < i_Pin.Length - 1)
                {
                    spaced.Append(' ');
                }
            }

            i_Pin.Clear();
            i_Pin.Append(spaced);
        }

        internal static bool IsValidGuess(eGuessValidation i_Syntax, eGuessValidation i_Logic)
        {
            return i_Syntax == eGuessValidation.Ok && i_Logic == eGuessValidation.Ok;
        }
    }
}
