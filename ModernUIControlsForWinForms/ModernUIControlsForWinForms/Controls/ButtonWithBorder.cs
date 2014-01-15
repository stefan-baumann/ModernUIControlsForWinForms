using ModernUIControlsForWinForms.Controls.Stuff;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls
{
    //Just a little modification to the Button Class so we don't need any code management.
    public class ButtonWithBorder : Button
    {
        public ButtonWithBorder()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonWithBorder_Paint);
            this.ResumeLayout(false);
        }

        private void ButtonWithBorder_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        public static void Draw(ButtonWithBorder button, Graphics g)
        {
            //Apply the DrawingSettings
            button.DrawingSettings.Apply(g);

            //Draw Background
            var BackColor = button.MouseState != MouseState.MouseDown ? button.BackColor : Color.Black;
            if (button.MouseState == MouseState.Hover)
                BackColor = BackColor.SetBrightness((float)Math.Max(0, Math.Min(1, BackColor.GetBrightness() * 1.0625)));
            g.Clear(BackColor);

            //Draw Text
            var TextColor = button.MouseState != MouseState.MouseDown ? button.ForeColor : button.ForeColor.SetBrightness(1 - button.ForeColor.GetBrightness());
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            g.DrawString(button.Text, button.Font, new SolidBrush(TextColor), button.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter });
        }
    }
}
