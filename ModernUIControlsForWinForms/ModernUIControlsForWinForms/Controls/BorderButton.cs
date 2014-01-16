using ModernUIControlsForWinForms.Controls.Stuff;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls
{
    public class BorderButton : System.Windows.Forms.Button
    {
        #region Initializing

        public BorderButton()
        {
            //Set Styles for Custom Control Painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);

            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            this.Size = new Size(115, 32);
            this.BackColor = Color.FromArgb(29, 29, 29);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Button_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            this.ResumeLayout(false);
        }

        #endregion

        #region Internal Variables/Properties

        private MouseState mouseState = MouseState.Normal;
        protected MouseState MouseState
        {
            get
            {
                return mouseState;
            }
            set
            {
                if (mouseState != value)
                {
                    mouseState = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Public Properties

        private DrawingSettings drawingSettings = DrawingSettings.HighQuality;
        public DrawingSettings DrawingSettings
        {
            get
            {
                return this.drawingSettings;
            }
            set
            {
                if (this.drawingSettings != value)
                {
                    this.drawingSettings = value;
                    this.Invalidate();
                }
            }
        }

        private Color borderColor = Color.White;
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                if (this.borderColor != value)
                {
                    this.borderColor = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Events

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseState = MouseState.Hover;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            this.MouseState = MouseState.Normal;
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            this.MouseState = MouseState.Hover;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseState = MouseState.MouseDown;
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter)
            {
                this.OnClick(EventArgs.Empty);
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            BorderButton.Draw(this, e.Graphics);
        }

        #endregion

        #region Drawing

        public static void Draw(BorderButton button, Graphics g)
        {
            //Apply the DrawingSettings
            button.DrawingSettings.Apply(g);

            //Draw Background
            var BackColor = button.MouseState != MouseState.MouseDown ? button.BackColor : button.BorderColor;
            if (button.MouseState == MouseState.Hover)
                BackColor = BackColor.SetBrightness((float)Math.Max(0, Math.Min(1, BackColor.GetBrightness() * 2)));
            g.Clear(BackColor);

            //Draw the Border
            g.DrawRectangle(new Pen(button.BorderColor, 2), new Rectangle(new Point(1, 1), new Size(button.Width - 2, button.Height - 2)));

            //Draw Text
            var TextColor = button.MouseState != MouseState.MouseDown ? button.BorderColor : button.ForeColor;
            g.DrawString(button.Text, button.Font, new SolidBrush(TextColor), button.ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter });
        }

        #endregion
    }
}
