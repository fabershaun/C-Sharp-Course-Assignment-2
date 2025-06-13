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
        private readonly List<PictureBox> r_TotalColorsToChoose = new List<PictureBox>();
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
                if(control is PictureBox pictureBox)
                {
                    if(r_UsedColors.Contains(pictureBox.BackColor))
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

            if(clickedBox.Enabled)
            {
                SelectedColor = clickedBox.BackColor;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
