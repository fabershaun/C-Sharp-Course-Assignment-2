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
    public partial class ColorPickForm : Form
    {
        private static readonly List<Color> sr_TotalColors = new List<Color>
        {
            Color.Red, Color.Green, Color.Blue, Color.Yellow,
            Color.Orange, Color.Purple, Color.Brown, Color.White
        };

        private readonly List<Color> r_UsedColors;
        private readonly List<PictureBox> r_AvailableColorBoxes = new List<PictureBox>();

        public static List<Color> TotalColors => sr_TotalColors;

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
            int rows = (int)Math.Ceiling((double)sr_TotalColors.Count / k_Columns);

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
                    if (colorIndex >= sr_TotalColors.Count)
                        break;

                    Color color = sr_TotalColors[colorIndex];
                    PictureBox pictureBox = new PictureBox
                    {
                        BackColor = color,
                        Width = k_BoxSize,
                        Height = k_BoxSize,
                        Margin = new Padding(k_Spacing),
                        BorderStyle = BorderStyle.FixedSingle,
                        Enabled = !r_UsedColors.Contains(color),
                    };

                    pictureBox.Click += onColorBoxClick;
                    r_AvailableColorBoxes.Add(pictureBox);
                    layout.Controls.Add(pictureBox, col, row);
                    colorIndex++;
                }
            }

            this.Controls.Add(layout);
        }

        private void onColorBoxClick(object sender, EventArgs e)
        {
            PictureBox clickedBox = sender as PictureBox;

            if (clickedBox.Enabled)
            {
                SelectedColor = clickedBox.BackColor;
                Tag = sr_TotalColors.IndexOf(clickedBox.BackColor);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }


    /*      private readonly List<PictureBox> r_TotalColorsToChoose = new List<PictureBox>();
            private readonly List<Color> r_UsedColors;



            public ColorPickForm(List<Color> i_UsedColors)
            {
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                collectColorBoxes();

                r_UsedColors = i_UsedColors;
                disableUsedColors();
                whenPictureBoxClicked();
            }

            public Color SelectedColor { get; private set; }

            public List<PictureBox> TotalColorsToChoose
            {
                get
                {
                    return r_TotalColorsToChoose;
                }
            }
            private void collectColorBoxes()
            {
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox pictureBox)
                    {
                        r_TotalColorsToChoose.Add(pictureBox);
                    }
                }
            }


            private void disableUsedColors()
            {
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox pictureBox)
                    {
                        if (r_UsedColors.Contains(pictureBox.BackColor))
                        {
                            pictureBox.Enabled = false;
                        }
                        else
                        {
                            pictureBox.Enabled = true;
                        }
                    }
                }
            }

            private void whenPictureBoxClicked()
            {
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox pictureBox)
                    {
                        pictureBox.Click += onColorBoxClick;
                    }
                }
            }

            private void onColorBoxClick(object sender, EventArgs e)
            {
                PictureBox clickedBox = sender as PictureBox;

                if (clickedBox.Enabled)
                {
                    SelectedColor = clickedBox.BackColor;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }*/
}

