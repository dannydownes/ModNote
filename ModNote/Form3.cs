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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            //sets date formats
            dateTimePicker1.CustomFormat = "dd/MM/yy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Today.AddDays(1);
            dateTimePicker2.CustomFormat = "dd/MM/yy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Value = DateTime.Today.AddDays(1);
            dateTimePicker3.CustomFormat = "dd/MM/yy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Value = DateTime.Today.AddDays(1);
            dateTimePicker4.CustomFormat = "dd/MM/yy";
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.Value = DateTime.Today.AddDays(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                Debug.WriteLine("Path 1: Empty course code.");
                MessageBox.Show("The module has to have a code.");
            }
            else if (String.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                Debug.WriteLine("Path 2: Empty title.");
                MessageBox.Show("The module has to have a title.");
            }
            else if (String.IsNullOrWhiteSpace(richTextBox3.Text))
            {
                Debug.WriteLine("Path 3: Empty synopsis.");
                MessageBox.Show("The module has to have a synopsis.");
            }
            else
            {
                Debug.WriteLine("Path 4: Save is okay.");
                // variables that create the new module
                string fileName = "../../Modules/" + richTextBox1.Text + ".txt";
                string noteFileName = "../../Notes/" + richTextBox1.Text + ".txt";
                string code = richTextBox1.Text;
                string title = richTextBox2.Text;
                string synopsis = richTextBox3.Text;

                string lo1 = "";
                string lo2 = "";
                string lo3 = "";
                string lo4 = "";
                string ass1 = "";

                DateTime date1 = dateTimePicker1.Value.Date;
                string ass2 = "";
                DateTime date2 = dateTimePicker2.Value.Date;
                string ass3 = "";
                DateTime date3 = dateTimePicker3.Value.Date;
                string ass4 = "";
                DateTime date4 = dateTimePicker4.Value.Date;


                //creates and/or misses learning objectives
                if (richTextBox4.Text != "")
                {
                    lo1 = "\nLO1 " + richTextBox4.Text;
                }
                else
                {
                    lo1 = null;
                }

                if (richTextBox5.Text != "")
                {
                    lo2 = "\nLO2 " + richTextBox5.Text;
                }
                else
                {
                    lo2 = null;
                }

                if (richTextBox6.Text != "")
                {
                    lo3 = "\nLO3 " + richTextBox6.Text;
                }
                else
                {
                    lo3 = null;
                }

                if (richTextBox7.Text != "")
                {
                    lo4 = "\nLO4 " + richTextBox7.Text;
                }
                else
                {
                    lo4 = null;
                }

                //creates and/or misses assignments
                if (comboBox1.Text == "Assignment" || comboBox1.Text == "Exam" || comboBox1.Text == "In-Class Test")
                {
                    ass1 = "\n" + comboBox1.Text + "\t" + dateTimePicker1.Value.ToShortDateString();
                }
                else
                {

                    ass1 = null;
                }

                if (comboBox2.Text == "Assignment" || comboBox2.Text == "Exam" || comboBox2.Text == "In-Class Test")
                {
                    ass2 = "\n" + comboBox2.Text + "\t" + dateTimePicker2.Value.ToShortDateString();
                }
                else
                {
                    ass2 = null;
                }

                if (comboBox3.Text == "Assignment" || comboBox3.Text == "Exam" || comboBox3.Text == "In-Class Test")
                {
                    ass3 = "\n" + comboBox3.Text + "\t" + dateTimePicker3.Value.ToShortDateString();
                }
                else
                {
                    ass3 = null;
                }

                if (comboBox4.Text == "Assignment" || comboBox4.Text == "Exam" || comboBox4.Text == "In-Class Test")
                {
                    ass4 = "\n" + comboBox4.Text + "\t" + dateTimePicker4.Value.ToShortDateString();
                }
                else
                {
                    ass4 = null;
                }

                //creates the module
                StreamWriter newModule;
                newModule = new StreamWriter(fileName);
                newModule.Write("CODE\n" + code + "\n\nTITLE\n" + title + "\n\nSYNOPSIS\n" + synopsis + "\n\nLO" + lo1 + lo2 + lo3 + lo4 + "\n\nASSIGNMENTS" + ass1 + ass2 + ass3 + ass4);
                File.Create(noteFileName).Dispose();
                newModule.Close();
                this.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //date picker for assignments
            DateTime chosen = dateTimePicker1.Value.Date;
            DateTime now = DateTime.Today.Date;

            int result = DateTime.Compare(chosen, now);

            if (result < 0)
            {
                MessageBox.Show("The date selected is for a date that has already passed.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
            else if (result == 0)
            {
                MessageBox.Show("The date selected is for today.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //date picker for assignments
            DateTime chosen = dateTimePicker2.Value;
            DateTime now = DateTime.Now;

            int result = DateTime.Compare(chosen, now);

            if (result < 0)
            {
                MessageBox.Show("The date selected is for a date that has already passed.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
            else if (result == 0)
            {
                MessageBox.Show("The date selected is for today.") ;
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            //date picker for assignments
            DateTime chosen = dateTimePicker3.Value;
            DateTime now = DateTime.Now;

            int result = DateTime.Compare(chosen, now);

            if (result < 0)
            {
                MessageBox.Show("The date selected is for a date that has already passed.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
            else if (result == 0)
            {
                MessageBox.Show("The date selected is for today.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            //date picker for assignments
            DateTime chosen = dateTimePicker4.Value;
            DateTime now = DateTime.Now;

            int result = DateTime.Compare(chosen, now);

            if (result < 0)
            {
                MessageBox.Show("The date selected is for a date that has already passed.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);

            }
            else if (result == 0)
            {
                MessageBox.Show("The date selected is for today.");
                dateTimePicker4.Value = DateTime.Now.AddDays(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
