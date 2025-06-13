using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Ex02
{
    internal class GuessRow1
    {
        public Button[] GuessButtons { get; }
        public Button SubmitButton { get; } = new Button();
        public PictureBox[] ResultUnits { get; }
        public int TopOffset { get; }

        private readonly int r_CodeLength;

        public event EventHandler<Button> ColorButtonClicked;

        public GuessRow1(int i_RowIndex, int i_TopStart, int i_CodeLength, int i_LeftOffset = 15)
        {
            const int k_Spacing = 10;
            const int k_Size = 45;
            int currentLeft = i_LeftOffset;

            r_CodeLength = i_CodeLength;
            TopOffset = i_TopStart + i_RowIndex * (k_Size + k_Spacing);

            GuessButtons = new Button[r_CodeLength];
            ResultUnits = new PictureBox[r_CodeLength];

            // Guess buttons
            for (int i = 0; i < r_CodeLength; i++)
            {
                GuessButtons[i] = new Button
                {
                    Size = new Size(k_Size, k_Size),
                    Left = currentLeft,
                    Top = TopOffset,
                    Enabled = i_RowIndex == 0 ? true : false,
                    BackColor = Color.LightGray
                };
                currentLeft += k_Size + k_Spacing;

                GuessButtons[i].Click += (sender, e) =>
                {
                    Button clickedButton = sender as Button;
                    ColorButtonClicked?.Invoke(this, clickedButton);
                };
            }

            // Submit button
            SubmitButton.Text = "->>";
            SubmitButton.Size = new Size(k_Size, 20);
            SubmitButton.Left = currentLeft;
            SubmitButton.Top = TopOffset + 10;
            SubmitButton.Enabled = false;
            currentLeft += SubmitButton.Width + k_Spacing;

            // Result units
            int resultBoxSize = 20;
            int resultGridRows = 2;
            int resultGridCols = r_CodeLength / resultGridRows;
            int resultUnitSpacing = 5;
            if (r_CodeLength % resultGridRows != 0)
            {
                resultGridCols++; // Adjust for odd number of columns
            }

            for (int i = 0; i < r_CodeLength; i++)
            {
                int row = i / resultGridCols;
                int col = i % resultGridCols;

                ResultUnits[i] = new PictureBox()
                {
                    Size = new Size(resultBoxSize, resultBoxSize),
                    BackColor = Color.LightGray,
                    Left = currentLeft + col * (resultBoxSize + resultUnitSpacing),
                    Top = TopOffset + row * (resultBoxSize + resultUnitSpacing),
                    Enabled = false,
                    BorderStyle = BorderStyle.FixedSingle
                };
            }
        }

        public void AddToForm(Form i_Form)
        {
            foreach (Button button in GuessButtons)
                i_Form.Controls.Add(button);

            i_Form.Controls.Add(SubmitButton);

            foreach (PictureBox box in ResultUnits)
                i_Form.Controls.Add(box);
        }

    }
}