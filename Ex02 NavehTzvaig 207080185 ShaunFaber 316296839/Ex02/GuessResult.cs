using System;

namespace Ex02
{
    internal class GuessResult
    {
        private int m_NumOfV = 0;
        private int m_NumOfX = 0;

        internal int NumOfV
        {
            get { return m_NumOfV; }
            set { m_NumOfV = value; }
        }

        internal int NumOfX
        {
            get { return m_NumOfX; }
            set { m_NumOfX = value; }
        }

        public string GetResult()
        {
            string result = m_NumOfV.ToString();
            result += NumOfX.ToString();

            return result;
        }
    }
}
