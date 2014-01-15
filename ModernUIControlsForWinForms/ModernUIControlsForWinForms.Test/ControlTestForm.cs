using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ModernUIControlsForWinForms.Test
{
    public partial class ControlTestForm : Form
    {
        public ControlTestForm()
        {
            InitializeComponent();
        }

        private List<Assembly> Assemblies = new List<Assembly>();

        private void ControlTestForm_Load(object sender, EventArgs e)
        {
            //Load all valid Assemblies from the startup folder.
            foreach(FileInfo file in new DirectoryInfo(Application.StartupPath).GetFiles("*.dll"))
            {
                try {
                    Assemblies.Add(Assembly.LoadFrom(file.FullName));
                }
                catch {
                    //Do nothing
                }
            }
            //Assign the assemblies to the ComboBox
            AssemblyComboBox.DataSource = Assemblies;
            AssemblyComboBox.DisplayMember = "FullName";

            SetAssembly();
        }

        private void AssemblyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetAssembly();
        }

        private void ControlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControl();
        }

        private void SetAssembly()
        {
            var Assembly = (Assembly)AssemblyComboBox.SelectedItem;
            var Controls = Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Control))).ToList();
            ControlComboBox.DataSource = Controls;
            ControlComboBox.DisplayMember = "Name";

            SetControl();
        }

        private Control CurrentControl = null;
        private void SetControl()
        {
            //Remove last Control
            if (CurrentControl !=null)
            {
                HostPanel.Controls.Remove(CurrentControl);
                CurrentControl.Dispose();
            }

            CurrentControl = (Control)Activator.CreateInstance((Type)ControlComboBox.SelectedItem);
            CurrentControl.Location = new Point(10, 10);
            HostPanel.Controls.Add(CurrentControl);
            TestControlPropertyGrid.SelectedObject = CurrentControl;
        }
    }
}
