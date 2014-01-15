namespace ModernUIControlsForWinForms.Test
{
    partial class ControlTestForm
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
            this.AssemblyComboBox = new System.Windows.Forms.ComboBox();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.HostPanel = new System.Windows.Forms.Panel();
            this.TestControlPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.ComboBoxPanel = new System.Windows.Forms.Panel();
            this.ControlComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.ComboBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AssemblyComboBox
            // 
            this.AssemblyComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.AssemblyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssemblyComboBox.FormattingEnabled = true;
            this.AssemblyComboBox.Location = new System.Drawing.Point(0, 0);
            this.AssemblyComboBox.Name = "AssemblyComboBox";
            this.AssemblyComboBox.Size = new System.Drawing.Size(731, 21);
            this.AssemblyComboBox.TabIndex = 0;
            this.AssemblyComboBox.SelectedIndexChanged += new System.EventHandler(this.AssemblyComboBox_SelectedIndexChanged);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 21);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.HostPanel);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.TestControlPropertyGrid);
            this.MainSplitContainer.Panel2.Controls.Add(this.ComboBoxPanel);
            this.MainSplitContainer.Size = new System.Drawing.Size(731, 443);
            this.MainSplitContainer.SplitterDistance = 492;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // HostPanel
            // 
            this.HostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostPanel.Location = new System.Drawing.Point(0, 0);
            this.HostPanel.Name = "HostPanel";
            this.HostPanel.Size = new System.Drawing.Size(492, 443);
            this.HostPanel.TabIndex = 0;
            // 
            // TestControlPropertyGrid
            // 
            this.TestControlPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestControlPropertyGrid.Location = new System.Drawing.Point(0, 22);
            this.TestControlPropertyGrid.Name = "TestControlPropertyGrid";
            this.TestControlPropertyGrid.Size = new System.Drawing.Size(235, 421);
            this.TestControlPropertyGrid.TabIndex = 1;
            // 
            // ComboBoxPanel
            // 
            this.ComboBoxPanel.Controls.Add(this.ControlComboBox);
            this.ComboBoxPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ComboBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.ComboBoxPanel.Name = "ComboBoxPanel";
            this.ComboBoxPanel.Size = new System.Drawing.Size(235, 22);
            this.ComboBoxPanel.TabIndex = 0;
            // 
            // ControlComboBox
            // 
            this.ControlComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ControlComboBox.FormattingEnabled = true;
            this.ControlComboBox.Location = new System.Drawing.Point(0, 1);
            this.ControlComboBox.Name = "ControlComboBox";
            this.ControlComboBox.Size = new System.Drawing.Size(235, 21);
            this.ControlComboBox.TabIndex = 2;
            this.ControlComboBox.SelectedIndexChanged += new System.EventHandler(this.ControlComboBox_SelectedIndexChanged);
            // 
            // ControlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(731, 464);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.AssemblyComboBox);
            this.Name = "ControlTestForm";
            this.Text = "ControlTestForm";
            this.Load += new System.EventHandler(this.ControlTestForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.ComboBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox AssemblyComboBox;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel ComboBoxPanel;
        private System.Windows.Forms.ComboBox ControlComboBox;
        private System.Windows.Forms.PropertyGrid TestControlPropertyGrid;
        private System.Windows.Forms.Panel HostPanel;

    }
}