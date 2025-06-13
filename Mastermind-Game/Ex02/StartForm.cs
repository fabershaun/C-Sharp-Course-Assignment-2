using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex02
{
    public partial class StartForm : Form
    {
        private int m_TotalNumberOfTries = GameLogic.MinPossibleTries;
        public StartForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            buttonNumberOfChances.Text = $"Number of chances: {m_TotalNumberOfTries}";
        }

        public int TotalNumberOfTries => m_TotalNumberOfTries;

        private void button1_Click(object sender, EventArgs e)
        {
            m_TotalNumberOfTries++;

            if (m_TotalNumberOfTries > GameLogic.MaxPossibleTries)
            {
                m_TotalNumberOfTries = GameLogic.MinPossibleTries;
            }

            buttonNumberOfChances.Text = $"Number of chances: {m_TotalNumberOfTries}";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
