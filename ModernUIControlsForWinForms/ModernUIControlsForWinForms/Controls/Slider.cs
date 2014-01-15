using ModernUIControlsForWinForms.Controls.Stuff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms
{
    /// <summary>
    /// A Control representing two States (On & Off) similar to a CheckBox
    /// </summary>
    public class Slider : Control
    {
        #region Initializing

        public Slider()
        {
            //Set Styles for Custom Control Painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Slider
            // 
            this.Size = new System.Drawing.Size(50, 19);
            this.Click += new System.EventHandler(this.Slider_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Slider_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Slider_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Slider_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Slider_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        #region Internal Variables

        protected MouseState MouseState = MouseState.Normal;

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

        private Color sliderOnColor = Color.FromArgb(0, 119, 198);
        public Color SliderOnColor
        {
            get
            {
                return this.sliderOnColor;
            }
            set
            {
                if (this.sliderOnColor != value)
                {
                    this.sliderOnColor = value;
                    this.Invalidate();
                }
            }
        }

        private Color sliderOffColor = Color.FromArgb(166, 166, 166);
        public Color SliderOffColor
        {
            get
            {
                return this.sliderOffColor;
            }
            set
            {
                if (this.sliderOffColor != value)
                {
                    this.sliderOffColor = value;
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

        private Color sliderColor = Color.Black;
        public Color SliderColor
        {
            get
            {
                return this.sliderColor;
            }
            set
            {
                if (this.sliderColor != value)
                {
                    this.sliderColor = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Events
        
        private void Slider_Click(object sender, EventArgs e)
        {
            this.On = !this.On;
        }

        private void Slider_KeyDown(object sender, KeyEventArgs e)
        {
            //The Spacebar toggles the Slider
            if (e.KeyCode == Keys.Space)
                this.On = !this.On;
        }

        private void Slider_Paint(object sender, PaintEventArgs e)
        {
            //Call the Method to draw the Slider
            Slider.Draw(this, e.Graphics);
        }

        private void Slider_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Slider_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Slider_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Slider_MouseUp(object sender, MouseEventArgs e)
        {

        }

        #endregion

        #region Drawing

        internal static void Draw(Slider slider, Graphics g)
        {
            //Draw the Border
            g.DrawRectangle(new Pen(slider.BorderColor, 2), new Rectangle(new Point(1, 1), new Size(slider.Width - 2, slider.Height - 2)));

            //Draw the middle part
            var InnerColor = GetInnerColor(slider.SliderOnColor, slider.SliderOnColor, slider.On, slider.MouseState);
            g.FillRectangle(new SolidBrush(InnerColor), new Rectangle(new Point(4, 4), new Size(slider.Width - 8, slider.Height - 8)));

            //Draw the Slider Bar
            var Slider = new Rectangle(new Point(slider.On ? slider.Width - 12 : 0, 0), new Size(12, slider.Height));
            g.FillRectangle(new SolidBrush(slider.SliderColor), Slider);

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
                        return ColorHelpers.ColorFromHSL(onColor.GetHue(), (float)Math.Max(0, Math.Max(1, onColor.GetSaturation() * 0.87)), (float)Math.Max(0, Math.Max(1, onColor.GetBrightness() * 1.20)));
                    case MouseState.MouseDown:
                        return ColorHelpers.ColorFromHSL(onColor.GetHue(), (float)Math.Max(0, Math.Max(1, onColor.GetSaturation() * 0.87)), (float)Math.Max(0, Math.Max(1, onColor.GetBrightness() * 1.45)));
                    default:
                        return onColor;
                }
            else
                switch (state) {
                    case MouseState.Hover:
                        return ColorHelpers.ColorFromHSL(offColor.GetHue(), offColor.GetSaturation(), (float)Math.Max(0, Math.Max(1, offColor.GetBrightness() * 1.075)));
                    case MouseState.MouseDown:
                        return ColorHelpers.ColorFromHSL(offColor.GetHue(), offColor.GetSaturation(), (float)Math.Max(0, Math.Max(1, offColor.GetBrightness() * 1.15)));
                    default:
                        return offColor;
                }
        }

        #endregion
    }
}
