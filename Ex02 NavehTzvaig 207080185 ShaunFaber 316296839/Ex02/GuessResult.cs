using System;

namespace Ex02
{
    internal class GuessResult
    {
        private string m_Guess;
        private int m_NumOfV = 0;
        private int m_NumOfX = 0;

        public string Guess
        {
            get { return m_Guess; }
            set { m_Guess = value; }
        }

        private void resultOfTheGuess() //Think avout use in game class
        {
            //Code.CompareGuessToCode(m_Guess, out m_NumOfV, out m_NumOfX);
        }

    }
}
