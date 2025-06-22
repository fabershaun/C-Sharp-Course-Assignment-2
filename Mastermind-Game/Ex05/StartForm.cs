using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();

            TotalNumberOfTries = GameLogic.MinPossibleTries;

            buttonNumberOfChances.Text = $"Number of chances: {TotalNumberOfTries}";
        }

        public int TotalNumberOfTries { get; private set; }

        private void buttonNumberOfChances_Click(object sender, EventArgs e)
        {
            TotalNumberOfTries++;

            if (TotalNumberOfTries > GameLogic.MaxPossibleTries)
            {
                TotalNumberOfTries = GameLogic.MinPossibleTries;
            }

            buttonNumberOfChances.Text = $"Number of chances: {TotalNumberOfTries}";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}