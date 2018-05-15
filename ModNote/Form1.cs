using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ModNote
{
    public partial class Form1 : Form
    {
        string originalText = "";
        string temp = "";
        public string output = "";

        public Form1()
        {
            //initializes
            InitializeComponent();
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //displays the module files
                string displayFile = " ";
                displayFile = File.ReadAllText(Path.Combine("../../Modules", listBox1.SelectedItem.ToString()));
                richTextBox1.Text = (displayFile);

                string assDisplayFile = " ";
                assDisplayFile = File.ReadAllText(Path.Combine("../../Modules", listBox1.SelectedItem.ToString()));
                richTextBox2.Text = (assDisplayFile);

                string noteDisplayFile = " ";
                noteDisplayFile = File.ReadAllText(Path.Combine("../../Notes/", listBox1.SelectedItem.ToString()));
                richTextBox3.Text = (noteDisplayFile);
            }
            catch
            {
                // stops error caused by clicking on white space in list box
                if (listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please choose a valid option");
                }
            }

            if (originalText != richTextBox1.Text)
            {
                {
                    //checks for any assignments or leaves assignment section blank
                    string[] lines = Regex.Split(richTextBox2.Text, "\n|\r");

                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Assignment"))
                        {
                            string dueDate = " ";
                            findDueDate(line, out dueDate);
                            temp += line + "\t" + dueDate + "\n";
                        }
                        else if (line.StartsWith("In-Class Test"))
                        {
                            string dueDate = " ";
                            findDueDate(line, out dueDate);
                            temp += line + "\t" + dueDate +"\n";
                        }
                        else if (line.StartsWith("Exam"))
                        {
                            string dueDate = " ";
                            findDueDate(line, out dueDate);
                            temp += line + "\t" + dueDate + "\n";
                        }
                        else if (line != null)
                        {
                            temp = "";
                        }
                        richTextBox2.Text = temp;
                    }
                }
            }
        }

        public void findDueDate (string test, out string output)
        {
            // finds any assignments and dates in the module files
            // displays whether the deadline has passed, is in the future or same day
            string findDate = test;
            output = "";
            try
            {
                // tries to find date in the format 01/01/1001
                Regex rgx = new Regex(@"\d{2}/\d{2}/\d{4}");
                Match mat = rgx.Match(findDate);
                Debug.WriteLine(mat);
                string tempString = mat.ToString();

                DateTime assignment = DateTime.ParseExact(tempString, "dd/MM/yyyy", null);
                DateTime now = DateTime.Today.Date;

                int result = DateTime.Compare(assignment, now);

                if (result < 0)
                {
                    output = "Deadline has passed.";
                    return;
                }
                else if (result == 0)
                {
                    output = "Deadline is today.";
                    return;
                }
                else if (result > 0)
                {
                    output = "Deadline is in the future.";
                    return;
                }
            }
            catch
            {
                //or tries to find date in format 01/01/01
                Regex rgx = new Regex(@"\d{2}/\d{2}/\d{2}");
                Match mat = rgx.Match(findDate);
                Debug.WriteLine(mat);
                string tempString = mat.ToString();

                DateTime assignment = DateTime.ParseExact(tempString, "dd/MM/yy", null);
                DateTime now = DateTime.Today.Date;

                int result = DateTime.Compare(assignment, now);

                if (result < 0)
                {
                    output = "Deadline has passed.";
                    return;
                }
                else if (result == 0)
                {
                    output = "Deadline is today.";
                    return;
                }
                else if (result > 0)
                {
                    output = "Deadline is in the future.";
                    return;
                }
            }
        }

        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            //populates list box
            listBox1.Items.Clear();

            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //opens notes form
            var notes = new Form2();
            notes.Show();
        }

        private void addModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens add module form
            var addModule = new Form3();
            addModule.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exits application
            Application.Exit();
        }

        private void addNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens notes form from file menu
            var notes = new Form2();
            notes.Show();
        }

        private void removeModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens delete module form
            var delete = new Form5();
            delete.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens about form
            var about = new Form7();
            about.Show();
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            //updates whenever the form is entered
            PopulateListBox(listBox1, "../../Modules", "*.txt");
        }
    }
}
