using ModernUIControlsForWinForms.Controls.Stuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls
{
    public class Rating : Control
    {
        #region Initializing

        public Rating()
        {
            //Set Styles for Custom Control Painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(200, 40);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Rating_Paint);
            this.ResumeLayout(false);
        }

        #endregion

        #region Events

        private void Rating_Paint(object sender, PaintEventArgs e)
        {
            Rating.Draw(this, e.Graphics);
        }

        #endregion

        #region Public Properties

        private int starCount = 5;
        public int StarCount
        {
            get
            {
                return this.starCount;
            }
            set
            {
                if (value != this.starCount)
                {
                    this.starCount = value;
                    this.Invalidate();
                }
            }
        }

        private int value = 4;
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value != this.value)
                {
                    this.value = value;
                    this.Invalidate();
                }
            }
        }

        private float innerRadius = 6;
        public float InnerRadius
        {
            get
            {
                return this.innerRadius;
            }
            set
            {
                if (value != this.innerRadius)
                {
                    this.innerRadius = value;
                    this.Invalidate();
                }
            }
        }

        private float outterRadius = 14;
        public float OutterRadius
        {
            get
            {
                return this.outterRadius;
            }
            set
            {
                if (value != this.outterRadius)
                {
                    this.outterRadius = value;
                    this.Invalidate();
                }
            }
        }

        public Color deselectedColor = Color.FromArgb(108, 108, 108);
        public Color DeselectedColor
        {
            get
            {
                return this.deselectedColor;
            }
            set
            {
                if (value != this.deselectedColor)
                {
                    this.deselectedColor = value;
                    this.Invalidate();
                }
            }
        }

        public Color selectedColor = Color.FromArgb(0, 119, 198);
        public Color SelectedColor
        {
            get
            {
                return this.selectedColor;
            }
            set
            {
                if (value != this.selectedColor)
                {
                    this.selectedColor = value;
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

        #region Drawing

        public static void Draw(Rating rating, Graphics g)
        {
            //Apply the DrawingSettings
            rating.DrawingSettings.Apply(g);

            //Draw the Stars
            var StarSpacing = rating.Width / (rating.StarCount);
            var MiddleY = rating.Height / 2;
            for (int i = 1; i < rating.StarCount + 1; i++)
            {
                g.FillPath(new SolidBrush(rating.value >= i ? rating.SelectedColor : rating.DeselectedColor), PathHelper.GenerateStar(new PointF((float)(StarSpacing * (i - .5)), MiddleY), 5, rating.InnerRadius, rating.OutterRadius, 90));
            }
        }

        #endregion

    }
}
