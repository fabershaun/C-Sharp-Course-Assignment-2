using System;
using System.Collections.Generic;

namespace Ex05
{
    internal class GameLogic
    {
        private const int k_CodeLength = 4;
        private const int k_RangeOfOptions = 8;
        private const int k_MinPossibleTries = 4;
        private const int k_MaxPossibleTries = 10;
        private readonly List<int> r_CodeElements = new List<int>(k_CodeLength);

        public static int CodeLength => k_CodeLength;

        public List<int> CodeElements => r_CodeElements;

        public static int MinPossibleTries => k_MinPossibleTries;

        public static int MaxPossibleTries => k_MaxPossibleTries;

        public void GenerateCode()
        {
            Random randomNumber = new Random();
            HashSet<int> usedNumbers = new HashSet<int>();
            int i = 0;

            while (i < k_CodeLength)
            {
                int index = randomNumber.Next(k_RangeOfOptions);

                if (!usedNumbers.Add(index)) // Ensure no duplicate numbers in the code
                {
                    continue;
                }

                r_CodeElements.Add(index);
                i++;
            }
        }

        internal bool CompareGuessToCode(List<int> i_OtherCode, out int o_NumOfBulls, out int o_NumOfCows)
        {
            o_NumOfBulls = 0;
            o_NumOfCows = 0;

            for (int i = 0; i < k_CodeLength; i++)
            {
                int guessElement = i_OtherCode[i];

                if (guessElement == r_CodeElements[i])
                {
                    o_NumOfBulls++;
                }
                else if (r_CodeElements.Contains(guessElement))
                {
                    o_NumOfCows++;
                }
            }

            return o_NumOfBulls == CodeLength;
        }
    }
}