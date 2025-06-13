using System.Text;

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

/*        public string GetResultString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < m_NumOfV; i++)
            {
                result.Append("V");
            }

            for (int i = 0; i < m_NumOfX; i++)
            {
                result.Append("X");
            }

            Code.SpacingPin(result);

            return result.ToString();
        }*/
    }
}
