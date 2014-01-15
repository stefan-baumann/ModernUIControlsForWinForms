namespace ModernUIControlsForWinForms.Test
{
    partial class MainForm
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
            this.slider1 = new ModernUIControlsForWinForms.Controls.Slider();
            this.SuspendLayout();
            // 
            // slider1
            // 
            this.slider1.Location = new System.Drawing.Point(66, 29);
            this.slider1.Name = "slider1";
            this.slider1.Size = new System.Drawing.Size(50, 19);
            this.slider1.SliderColor = System.Drawing.Color.Empty;
            this.slider1.TabIndex = 0;
            this.slider1.Text = "slider1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.slider1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.Slider slider1;
    }
}