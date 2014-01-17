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

            //Redirect all Events raised by the Internal TextBox to the custom Events
            this.Base.AcceptsTabChanged += this.OnAcceptsTabChanged;
            this.Base.BorderStyleChanged += this.OnBorderStyleChanged;
            this.Base.Click += this.OnClick;
            this.Base.MouseClick += this.OnMouseClick;
            this.Base.HideSelectionChanged += this.OnHideSelectionChanged;
            this.Base.ModifiedChanged += this.OnModifiedChanged;
            this.Base.MultilineChanged += this.OnMultilineChanged;
            this.Base.ReadOnlyChanged += this.OnReadOnlyChanged;
            this.Base.DoubleClick += this.OnDoubleClick;
            this.Base.KeyDown += this.KeyDown;
            this.Base.KeyPress += this.KeyPress;
            this.Base.KeyUp += this.KeyUp;
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

        #region TextBox Events

        public event EventHandler AcceptsTabChanged;
        private void OnAcceptsTabChanged(object sender, EventArgs e)
        { if (this.AcceptsTabChanged != null) this.AcceptsTabChanged(this, e); }

        public event EventHandler BorderStyleChanged;
        private void OnBorderStyleChanged(object sender, EventArgs e)
        { if (this.BorderStyleChanged != null) this.BorderStyleChanged(this, e); }

        public new event EventHandler Click;
        private void OnClick(object sender, EventArgs e)
        { if (this.Click != null) this.Click(this, e); }

        public new event EventHandler MouseClick;
        private void OnMouseClick(object sender, EventArgs e)
        { if (this.MouseClick != null) this.MouseClick(this, e); }

        public event EventHandler HideSelectionChanged;
        private void OnHideSelectionChanged(object sender, EventArgs e)
        { if (this.HideSelectionChanged != null) this.HideSelectionChanged(this, e); }

        public event EventHandler ModifiedChanged;
        private void OnModifiedChanged(object sender, EventArgs e)
        { if (this.ModifiedChanged != null) this.ModifiedChanged(this, e); }

        public event EventHandler MultilineChanged;
        private void OnMultilineChanged(object sender, EventArgs e)
        { if (this.MultilineChanged != null) this.MultilineChanged(this, e); }

        public event EventHandler ReadOnlyChanged;
        private void OnReadOnlyChanged(object sender, EventArgs e)
        { if (this.ReadOnlyChanged != null) this.ReadOnlyChanged(this, e); }

        public new event EventHandler DoubleClick;
        private void OnDoubleClick(object sender, EventArgs e)
        { if (this.DoubleClick != null) this.DoubleClick(this, e); }

        public new event KeyEventHandler KeyDown;
        private void OnKeyDown(object sender, KeyEventArgs e)
        { if (this.KeyDown != null) this.KeyDown(this, e); }

        public new event KeyPressEventHandler KeyPress;
        private void OnKeyPress(object sender, KeyPressEventArgs e)
        { if (this.KeyPress != null) this.KeyPress(this, e); }

        public new event KeyEventHandler KeyUp;
        private void OnKeyUp(object sender, KeyEventArgs e)
        { if (this.KeyUp != null) this.KeyUp(this, e); }

        #endregion
    }
}
