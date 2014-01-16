using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

            //Load all Systemcolors and set the selected Color to "Window"
            BackgroundComboBox.DisplayMember = "Item1";
            BackgroundComboBox.Items.AddRange(typeof(SystemColors).GetProperties().Where(pi => pi.PropertyType.FullName == "System.Drawing.Color").Select(pi => Tuple.Create<string, Color>(pi.Name, (Color)pi.GetValue(null, null))).ToArray());
            BackgroundComboBox.SelectedIndex = BackgroundComboBox.Items.Count - 3;
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

            var CurrentType = (Type)ControlComboBox.SelectedItem;
            CurrentControl = (Control)Activator.CreateInstance(CurrentType);
            CurrentControl.Location = new Point(10, 10);
            CurrentControl.Name = string.Format("{0}1", CurrentType.Name);
            if (string.IsNullOrWhiteSpace(CurrentControl.Text))
                CurrentControl.Text = CurrentControl.Name;

            //Add new Control
            HostPanel.Controls.Add(CurrentControl);
            TestControlPropertyGrid.SelectedObject = CurrentControl;
        }

        private void BackgroundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HostPanel.BackColor = ((Tuple<string, Color>)BackgroundComboBox.SelectedItem).Item2;
        }
    }
}
