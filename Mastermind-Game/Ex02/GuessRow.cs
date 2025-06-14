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
        private List<PictureBox> m_ResultGuess;
        private readonly bool[] r_IsColorChosen = new bool[4];
        private readonly List<int> r_GuessButtonsIndexes = new List<int>();
        public event EventHandler GuessSubmitted;

        public GuessRow()
        {
            InitializeComponent();
            initializeGuessButtonsList();
        }

        public List<int> GuessButtonIndexes => r_GuessButtonsIndexes;

        public List<PictureBox> ResultGuess => m_ResultGuess;

        private void initializeGuessButtonsList()
        {
            m_GuessButtons = new List<Button> { button1, button2, button3, button4 };
            m_ResultGuess = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

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

            using (ColorPickForm colorForm = new ColorPickForm(usedColors)) //TODO
            {
                if (colorForm.ShowDialog() == DialogResult.OK)
                {
                    clickedButton.BackColor = colorForm.SelectedColor;
                    clickedButton.Tag = colorForm.Tag;
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
            (sender as Button).Enabled = false;   // Disable the submit button after submission

            foreach(Button button in m_GuessButtons)
            {
                if (button.Tag is int index)
                {
                    r_GuessButtonsIndexes.Add(index);
                }
            }

            GuessSubmitted?.Invoke(this, EventArgs.Empty);
        }
    }
}
