using ModernUIControlsForWinForms.Controls.Stuff;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls
{
    /// <summary>
    /// A Control representing two States (On & Off) similar to a CheckBox
    /// </summary>
    public class Switch : Control
    {
        #region Initializing

        public Switch()
        {
            //Set Styles for Custom Control Painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(50, 19);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Switch_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Switch_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Switch_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Switch_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Switch_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Switch_MouseUp);
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

        private bool on = true;
        public bool On
        {
            get
            {
                return this.on;
            }
            set
            {
                if (this.on != value)
                {
                    this.on = value;
                    this.Invalidate();
                }
            }
        }

        private Color switchOnColor = Color.FromArgb(0, 119, 198);
        public Color SwitchOnColor
        {
            get
            {
                return this.switchOnColor;
            }
            set
            {
                if (this.switchOnColor != value)
                {
                    this.switchOnColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color switchOffColor = Color.FromArgb(166, 166, 166);
        public Color SwitchOffColor
        {
            get
            {
                return this.switchOffColor;
            }
            set
            {
                if (this.switchOffColor != value)
                {
                    this.switchOffColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color borderColor = Color.FromArgb(166, 166, 166);
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

        private Color switchColor = Color.Black;
        public Color SwitchColor
        {
            get
            {
                return this.switchColor;
            }
            set
            {
                if (this.switchColor != value)
                {
                    this.switchColor = value;
                    this.Invalidate();
                }
            }
        }

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

        #endregion

        #region Events
        
        private void Switch_KeyDown(object sender, KeyEventArgs e)
        {
            //The Spacebar toggles the Switch
            if (e.KeyCode == Keys.Space)
                this.On = !this.On;
        }

        private void Switch_Paint(object sender, PaintEventArgs e)
        {
            //Call the Method to draw the Switch
            Switch.Draw(this, e.Graphics);
        }

        private void Switch_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseState = MouseState.MouseDown;
        }

        private void Switch_MouseEnter(object sender, EventArgs e)
        {
            this.MouseState = MouseState.Hover;
        }

        private void Switch_MouseLeave(object sender, EventArgs e)
        {
            this.MouseState = MouseState.Normal;
        }

        private void Switch_MouseUp(object sender, MouseEventArgs e)
        {
            this.MouseState = MouseState.Hover;
            this.On = !this.On;
        }

        #endregion

        #region Drawing

        public static void Draw(Switch @switch, Graphics g)
        {
            //Apply the DrawingSettings
            @switch.DrawingSettings.Apply(g);

            //Draw the Border
            g.DrawRectangle(new Pen(@switch.BorderColor, 2), new Rectangle(new Point(1, 1), new Size(@switch.Width - 2, @switch.Height - 2)));

            //Draw the middle part
            var InnerColor = GetInnerColor(@switch.SwitchOnColor, @switch.SwitchOffColor, @switch.On, @switch.MouseState);
            g.FillRectangle(new SolidBrush(InnerColor), new Rectangle(new Point(4, 4), new Size(@switch.Width - 8, @switch.Height - 8)));

            //Draw the Switch Bar
            var SwitchPart = new Rectangle(new Point(@switch.On ? @switch.Width - 12 : 0, 0), new Size(12, @switch.Height));
            g.FillRectangle(new SolidBrush(@switch.SwitchColor), SwitchPart);

        }

        /* Some Information on how the calculation of the colors used in this control work
         * -------------------------------------------------------------------------------
         * Sample for the coloring of the colored part of the control:
         *  RGB: {R: 0; G: 119; B: 198}; HSL: {H: 203.9394; S: 1; L: 0.3882353} (Normal, Base Color)
         *  RGB: {R: 15; G: 140; B: 223}; HSL: {H: 203.9423; S: 0.8739496; L: 0.4666667} (Hover)
         *  RGB: {R: 100; G: 187; B: 244}; HSL: {H: 203.75; S: 0.8674697; L: 0.6745098} (MouseDown)
         *  => H-Value:
         *        HHover = HMouseDown = HNormal
         *     S-Value:
         *        SHover = SMouseDown = (SNormal * 0.87)
         *     L-Value:
         *        LHover = Clamp(LNormal * 1.20)
         *        LMouseDown = Clamp(LNormal * 1.45)
         *      
         * 
         * ...and the same for the not colored part of the control:
         *  RGB: {R: 166; G: 166; B: 166}; HSL: {H: 0; S: 0; L: 0.6509804} (Normal, Base Color)
         *  RGB: {R: 181; G: 181; B: 181}; HSL: {H: 0; S: 0; L: 0.7098039} (Hover)
         *  RGB: {R: 189; G: 189; B: 189}; HSL: {H: 0; S: 0; L: 0.7411765} (MouseDown)
         *  => H-Value:
         *        HHover = HMouseDown = HNormal = 0
         *     S-Value:
         *        SHover = SMouseDown = SNormal = 0
         *     L-Value:
         *        LHover = Clamp(LNormal * 1.075))
         *        LMouseDown = Clamp(LNormal * 1.15))
         */
        private static Color GetInnerColor(Color onColor, Color offColor, bool on, MouseState state)
        {
            if (on)
                switch (state) {
                    case MouseState.Hover:
                        return ColorHelpers.ColorFromHSL(onColor.GetHue(), (float)Math.Max(0, Math.Min(1, onColor.GetSaturation() * 0.87)), (float)Math.Max(0, Math.Min(1, onColor.GetBrightness() * 1.20)));
                    case MouseState.MouseDown:
                        return ColorHelpers.ColorFromHSL(onColor.GetHue(), (float)Math.Max(0, Math.Min(1, onColor.GetSaturation() * 0.87)), (float)Math.Max(0, Math.Min(1, onColor.GetBrightness() * 1.45)));
                    default:
                        return onColor;
                }
            else
                switch (state) {
                    case MouseState.Hover:
                        return ColorHelpers.ColorFromHSL(offColor.GetHue(), offColor.GetSaturation(), (float)Math.Max(0, Math.Min(1, offColor.GetBrightness() * 1.075)));
                    case MouseState.MouseDown:
                        return ColorHelpers.ColorFromHSL(offColor.GetHue(), offColor.GetSaturation(), (float)Math.Max(0, Math.Min(1, offColor.GetBrightness() * 1.15)));
                    default:
                        return offColor;
                }
        }

        #endregion
    }
}
