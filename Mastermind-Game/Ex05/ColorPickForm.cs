using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05
{
    public class ColorPickForm : Form
    {
        private readonly List<Color> r_UsedColors;

        public static List<Color> TotalColors { get; } = new List<Color>
        { 
            Color.Red, Color.Green, Color.Blue, Color.Yellow,
            Color.Orange, Color.Purple, Color.Brown, Color.White
        };

        public Color SelectedColor { get; private set; }

        public ColorPickForm(List<Color> i_UsedColors)
        {
            r_UsedColors = i_UsedColors;

            this.Text = "Pick A Color";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.LavenderBlush;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            initializeColorBoxes();
        }

        private void initializeColorBoxes()
        {
            const int k_BoxSize = 50;
            const int k_Spacing = 10;
            const int k_Columns = 4;
            int rows = (int)Math.Ceiling((double)TotalColors.Count / k_Columns);

            TableLayoutPanel layout = new TableLayoutPanel
            {
                RowCount = rows,
                ColumnCount = k_Columns,
                AutoSize = true,
                Padding = new Padding(k_Spacing),
                Margin = new Padding(k_Spacing),
                BackColor = Color.Transparent
            };

            int colorIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                for (int col = 0; col < k_Columns; col++)
                {
                    if (colorIndex >= TotalColors.Count)
                    {
                        break;
                    }

                    Color color = TotalColors[colorIndex];

                    Button button = new Button
                    {
                        BackColor = color,
                        Width = k_BoxSize,
                        Height = k_BoxSize,
                        Margin = new Padding(k_Spacing),
                        Enabled = !r_UsedColors.Contains(color),
                        TabIndex = colorIndex,
                        TabStop = true
                    };

                    button.Click += onColorBoxClick;
                    layout.Controls.Add(button, col, row);
                    colorIndex++;
                }
            }

            this.Controls.Add(layout);
        }

        private void onColorBoxClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton.Enabled)
            {
                SelectedColor = clickedButton.BackColor;
                Tag = TotalColors.IndexOf(clickedButton.BackColor);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}