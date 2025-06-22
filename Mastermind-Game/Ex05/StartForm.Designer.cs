using System.Windows.Forms;

namespace Ex05
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNumberOfChances = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNumberOfChances
            // 
            this.buttonNumberOfChances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNumberOfChances.Location = new System.Drawing.Point(12, 36);
            this.buttonNumberOfChances.Name = "buttonNumberOfChances";
            this.buttonNumberOfChances.Size = new System.Drawing.Size(463, 98);
            this.buttonNumberOfChances.TabIndex = 1;
            this.buttonNumberOfChances.UseVisualStyleBackColor = true;
            this.buttonNumberOfChances.Click += new System.EventHandler(this.buttonNumberOfChances_Click);
            // 
            // Start
            // 
            this.Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Start.Location = new System.Drawing.Point(368, 170);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(106, 46);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // StartForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Equation;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 234);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.buttonNumberOfChances);
            this.Name = "StartForm";
            this.Text = "Mastermind Game";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion
        private System.Windows.Forms.Button buttonNumberOfChances;
        private System.Windows.Forms.Button Start;
    }
}