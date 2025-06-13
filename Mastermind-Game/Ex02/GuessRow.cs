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
    public partial class GuessRow : UserControl
    {
        private List<Button> m_GuessButtons;
        private readonly bool[] r_IsColorChosen = new bool[4];

        public event EventHandler GuessSubmitted;

        public GuessRow()
        {
            InitializeComponent();
            initializeGuessButtonsList();
        }

        private void initializeGuessButtonsList()
        {
            m_GuessButtons = new List<Button> { button1, button2, button3, button4 };

            foreach (Button button in m_GuessButtons)
            {
                button.Click += onGuessButtonClick;
            }
        }

        public void EnableGuessing(bool i_Enabled)
        {
            foreach (Button button in m_GuessButtons)
            {
                button.Enabled = i_Enabled;
            }
        }

        private void updateSubmitButtonState()
        {
            bool readyToSubmit = true;

            foreach (bool isChosen in r_IsColorChosen)
            {
                if(isChosen)
                {
                    continue;
                }

                readyToSubmit = false;
                break;
            }

            button5.Enabled = readyToSubmit;
        }

        private void onGuessButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            List<Color> usedColors = new List<Color>();

            foreach (Button button in m_GuessButtons)
            {
                if (button != clickedButton && button.BackColor != SystemColors.Control)
                {
                    usedColors.Add(button.BackColor);
                }
            }

            using (ColorPickForm colorForm = new ColorPickForm(usedColors))
            {
                if (colorForm.ShowDialog() == DialogResult.OK)
                {
                    clickedButton.BackColor = colorForm.SelectedColor;
                    updateIsColorChosen(clickedButton);
                }
            }
        }

        private void updateIsColorChosen(Button clickedButton)
        {
            int indexOfGuessButton = m_GuessButtons.IndexOf(clickedButton);

            if (indexOfGuessButton >= 0)
            {
                r_IsColorChosen[indexOfGuessButton] = true;
                updateSubmitButtonState();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            bool setSubmittedButton = true;

            (sender as Button).Enabled = false;   // Disable the submit button after submission

            GuessSubmitted?.Invoke(this, EventArgs.Empty);
        }
    }
}
