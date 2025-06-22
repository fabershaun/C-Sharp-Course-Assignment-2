using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public partial class GuessRow : UserControl
    {
        private List<Button> m_GuessButtons;
        private readonly bool[] r_IsColorChosen = new bool[4];
        public List<int> GuessButtonIndexes { get; } = new List<int>();
        public List<PictureBox> ResultGuess { get; private set; }

        public event EventHandler GuessSubmitted;

        public GuessRow()
        {
            InitializeComponent();
            initializeGuessButtonsList();
        }
        
        private void initializeGuessButtonsList()
        {
            m_GuessButtons = new List<Button> { button1, button2, button3, button4 };
            ResultGuess = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

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
                    if(clickedButton != null)
                    {
                        clickedButton.BackColor = colorForm.SelectedColor;
                        clickedButton.Tag = colorForm.Tag;
                        updateIsColorChosen(clickedButton);
                    }
                }
            }
        }

        private void updateIsColorChosen(Button i_ClickedButton)
        {
            int indexOfGuessButton = m_GuessButtons.IndexOf(i_ClickedButton);

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
                    GuessButtonIndexes.Add(index);
                }
            }

            GuessSubmitted?.Invoke(this, EventArgs.Empty);
        }
    }
}