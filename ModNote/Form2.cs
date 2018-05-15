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
using System.Diagnostics;

namespace ModNote
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //initializes
            InitializeComponent();
            PopulateComboBox(comboBox1, "../../Modules", "*.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select a module.");
                Debug.WriteLine("Module is missing.");
            }
            else if (String.IsNullOrWhiteSpace(richTextBox1.Text)) 
            {
                MessageBox.Show("Please input a title.");
                Debug.WriteLine("Title is missing.");
            }
            else if (String.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                MessageBox.Show("Please input a note.");
                Debug.WriteLine("Note is missing");
            }
            else
            {
                //creates the new note for premade modules
                string location = "../../Notes/" + (comboBox1.Text);
                string title = richTextBox1.Text;
                string note = richTextBox2.Text;
                //if no previous notes
                string newFormat = "Title: " + title + "\nNote: " + note;
                //if contains previous notes
                string format = "\n\n========================================================\n\nTitle: " + title + "\nNote: " + note;
            
                if (richTextBox3.Text == "")
                {
                    richTextBox3.AppendText(newFormat);
                }
                else if (richTextBox3.Text != "")
                {
                    richTextBox3.AppendText(format);
                }
           
                richTextBox3.SaveFile(@"../../Notes/" + (comboBox1.Text), RichTextBoxStreamType.PlainText);
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                Debug.WriteLine("Notes has been added successfully.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //closes form
            Debug.WriteLine("Add note form closed.");
            this.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //turns selected item into a string
            string displayFile = "";
            displayFile = File.ReadAllText(Path.Combine("../../Notes", comboBox1.SelectedItem.ToString()));
            richTextBox3.Text = (displayFile);
            Debug.WriteLine("Item Selected.");
        }

        private void PopulateComboBox(ComboBox cbx, string Folder, string FileType)
        {
            //populates combo box
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                cbx.Items.Add(file.Name);
            }
            Debug.WriteLine("Combo box has been populated.");
        }
    }
}
