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
        private readonly List<Color> r_UsedColors;

        public ColorPickForm(List<Color> i_UsedColors)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            r_UsedColors = i_UsedColors;
            disableUsedColors();
            whenPictureBoxClicked();
        }

        public Color SelectedColor { get; private set; }

        private void disableUsedColors()
        {
            foreach (Control control in this.Controls)
            {
                if(control is PictureBox pictureBox)
                {
                    if(r_UsedColors.Contains(pictureBox.BackColor))
                    {
                        pictureBox.Enabled = false;
                        pictureBox.Cursor = Cursors.No;
                    }
                    else
                    {
                        pictureBox.Enabled = true;
                        pictureBox.Cursor = Cursors.Hand;
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

            if(clickedBox.Enabled)
            {
                SelectedColor = clickedBox.BackColor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
