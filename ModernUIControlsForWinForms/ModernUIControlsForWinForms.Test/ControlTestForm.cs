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

        private void SetControl()
        {
            //Remove last Control


            var Control = (Control)Activator.CreateInstance((Type)ControlComboBox.SelectedItem);
            HostPanel.Controls.Add(Control);
            TestControlPropertyGrid.SelectedObject = Control;
        }
    }
}
