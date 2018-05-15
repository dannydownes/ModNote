using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ModNote
{
    public partial class Form5 : Form
    {
        string delete;

        public Form5()
        {
            InitializeComponent();
            PopulateComboBox(comboBox1, "../../Modules", "*.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel button closes form
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //combo box turns to string
            delete = comboBox1.SelectedItem.ToString();
        }

        private void PopulateComboBox(ComboBox cbx, string Folder, string FileType)
        {
            //populates the combo box
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                cbx.Items.Add(file.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                this.Close();
            }
            else
            {
                //deletes the given module and notes file
                File.Delete(@"../../Modules/" + delete);
                File.Delete(@"../../Notes/" + delete);
                this.Close();
            }
            
        }
    }
}
