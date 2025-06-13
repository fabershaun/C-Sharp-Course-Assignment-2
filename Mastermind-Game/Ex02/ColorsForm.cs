using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Ex02
{
    internal class ColorsForm : Form
    {
        private readonly int r_NumberOfColors = Code.NumOfPossibleOptions;
        private readonly List<Color> r_Colors = new List<Color>();
        private HashSet<int> r_ColorsChoices = new HashSet<int>();

        public ColorsForm()
        {
            createColorsList(); 

            if (r_NumberOfColors > r_Colors.Count)
            {
                throw new InvalidOperationException("Not enough colors defined for the current configuration.");
            }

            this.Text = "Pick A Color:";
            this.BackColor = Color.LavenderBlush;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoSize = true;

            initializeComponents();
        }

        private void initializeComponents()
        {
            const int k_ButtonSize = 50;
            const int k_Spacing = 10;
            int numPerRow = r_NumberOfColors / 2;

            List<Button> colorButtons = new List<Button>();

            for (int i = 0; i < r_NumberOfColors; i++)
            {
                int row = i / numPerRow; // 0 or 1   
                int col = i % numPerRow; 

                Button colorButton = new Button
                                         {
                                             BackColor = r_Colors[i],
                                             Size = new Size(k_ButtonSize, k_ButtonSize),
                                             Left = k_ButtonSize + col * (k_ButtonSize + k_ButtonSize),
                                             Top = k_ButtonSize + row * (k_ButtonSize + k_ButtonSize)
                                         };

                colorButton.Click += (sender, e) =>
                    {
                        Button clicked = sender as Button;
                        SelectedColor = clicked.BackColor;
                        //r_ColorsChoices.Add() /// להמשיך עם האינדקסים
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    };
                colorButtons.Add(colorButton);
                this.Controls.Add(colorButton);
            }
        }

        public Color SelectedColor { get; private set; }

        private void createColorsList()
        {
            r_Colors.Add(Color.DarkRed);
            r_Colors.Add(Color.Coral);
            r_Colors.Add(Color.Gold);
            r_Colors.Add(Color.MediumAquamarine);
            r_Colors.Add(Color.DodgerBlue);
            r_Colors.Add(Color.LightPink);
            r_Colors.Add(Color.HotPink);
            r_Colors.Add(Color.MediumPurple);
            r_Colors.Add(Color.Khaki);
            r_Colors.Add(Color.LawnGreen);
            r_Colors.Add(Color.Teal);
            r_Colors.Add(Color.Salmon);
            r_Colors.Add(Color.Turquoise);
        }
    }

}
