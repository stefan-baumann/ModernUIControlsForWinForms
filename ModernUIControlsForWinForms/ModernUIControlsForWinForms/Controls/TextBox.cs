using ModernUIControlsForWinForms.Controls.Stuff;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Controls
{
    public partial class TextBox : Control
    {
        #region Initializing

        public TextBox()
        {
            //Set Styles for Custom Control Painting
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Size = new System.Drawing.Size(50, 19);
            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.Slider_Paint);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Slider_KeyDown);
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Slider_MouseDown);
            //this.MouseEnter += new System.EventHandler(this.Slider_MouseEnter);
            //this.MouseLeave += new System.EventHandler(this.Slider_MouseLeave);
            //this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Slider_MouseUp);
            this.ResumeLayout(false);
        }

        #endregion

        #region Internal Variables/Properties

        private System.Windows.Forms.TextBox @base = new System.Windows.Forms.TextBox();
        protected System.Windows.Forms.TextBox Base
        {
            get
            {
                return @base;
            }
            set
            {
                if (@base != value)
                {
                    @base = value;
                    this.Invalidate();
                }
            }
        }

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

        public static void Draw(Switch slider, Graphics g)
        {
            //Apply the DrawingSettings
            slider.DrawingSettings.Apply(g);

            //Draw the Border
            g.DrawRectangle(new Pen(slider.BorderColor, 2), new Rectangle(new Point(1, 1), new Size(slider.Width - 2, slider.Height - 2)));
        }
        #endregion

        #region TextBox Properties

        public bool AcceptsTab
        {
            get { return this.Base.AcceptsTab; }
            set { this.Base.AcceptsTab = value; }
        }

        public bool ShortcutsEnabled
        {
            get { return this.Base.ShortcutsEnabled; }
            set { this.Base.ShortcutsEnabled = value; }
        }

        public override bool AutoSize
        {
            get { return this.Base.AutoSize; }
            set { this.Base.AutoSize = value; }
        }

        public override Color BackColor
        {
            get { return this.Base.BackColor; }
            set { this.Base.BackColor = value; }
        }

        public override Color ForeColor
        {
            get { return this.Base.ForeColor; }
            set { this.Base.ForeColor = value; }
        }

        public bool HideSelection
        {
            get { return this.Base.HideSelection; }
            set { this.Base.HideSelection = value; }
        }

        public string[] Lines
        {
            get { return this.Base.Lines; }
            set { this.Base.Lines = value; }
        }

        public int MaxLength
        {
            get { return this.Base.MaxLength; }
            set { this.Base.MaxLength = value; }
        }

        public bool Modified
        {
            get { return this.Base.Modified; }
            set { this.Base.Modified = value; }
        }

        public bool Multiline
        {
            get { return this.Base.Multiline; }
            set { this.Base.Multiline = value; }
        }

        public bool ReadOnly
        {
            get { return this.Base.ReadOnly; }
            set { this.Base.ReadOnly = value; }
        }

        public string SelectedText
        {
            get { return this.Base.SelectedText; }
            set { this.Base.SelectedText = value; }
        }

        public int SelectionLength
        {
            get { return this.Base.SelectionLength; }
            set { this.Base.SelectionLength = value; }
        }

        public int SelectionStart
        {
            get { return this.Base.SelectionStart; }
            set { this.Base.SelectionStart = value; }
        }

        public override string Text
        {
            get { return this.Base.Text; }
            set { this.Base.Text = value; }
        }

        public int TextLength
        {
            get { return this.Base.TextLength; }
        }

        #endregion

        #region TextBox Methods

        public void AppendText(string text)
        {
            this.Base.AppendText(text);
        }

        public void Clear()
        {
            this.Base.Clear();
        }

        public void ClearUndo()
        {
            this.Base.ClearUndo();
        }

        public void Copy()
        {
            this.Base.Copy();
        }

        public void Cut()
        {
            this.Base.Cut();
        }

        public void Paste()
        {
            this.Base.Paste();
        }

        public void GetCharFromPosition(Point pt)
        {
            this.Base.GetCharFromPosition(pt);
        }

        public void GetCharIndexFromPosition(Point pt)
        {
            this.Base.GetCharIndexFromPosition(pt);
        }

        public void GetLineFromCharIndex(int index)
        {
            this.Base.GetLineFromCharIndex(index);
        }

        public void GetPositionFromCharIndex(int index)
        {
            this.Base.GetPositionFromCharIndex(index);
        }

        public int GetFirstCharIndexFromLine(int lineNumber)
        {
            return this.Base.GetFirstCharIndexFromLine(lineNumber);
        }

        public int GetFirstCharIndexOfCurrentLine()
        {
            return this.Base.GetFirstCharIndexOfCurrentLine();
        }

        public void ScrollToCaret()
        {
            this.Base.ScrollToCaret();
        }

        public void DeselectAll()
        {
            this.Base.DeselectAll();
        }

        public void Select(int start, int length)
        {
            this.Base.Select(start, length);
        }

        public void SelectAll()
        {
            this.Base.SelectAll();
        }

        public override string ToString()
        {
            return this.Base.ToString();
        }

        public void Undo()
        {
            this.Base.Undo();
        }

        #endregion
    }
}
