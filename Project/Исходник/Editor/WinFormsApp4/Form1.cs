using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        string Path;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button1.Enabled = false;
            label1.Text = "";
           
            //if (!label1.Text.EndsWith("\n"))
            //{
            //    string Path = @"./Texts.txt";
            //    try
            //    {
            //        using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
            //        {
            //            sw.WriteLine();
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            checkBox2.Checked = false;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && (checkBox1.Checked || checkBox2.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                checkBox1.Checked = false;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && (checkBox1.Checked || checkBox2.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" &&(checkBox1.Checked || checkBox2.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && (checkBox1.Checked || checkBox2.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && (checkBox1.Checked || checkBox2.Checked))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string S = textBox1.Text + " | " + textBox2.Text + " | " + textBox3.Text+" | ";
            if (checkBox1.Checked)
                S += "1";
            if (checkBox2.Checked)
                S += "2";
           
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.Default))
                {
            //        sw.WriteLine();
                    sw.WriteLine(S);
                }
            }
            catch (Exception E)
            {

            }
            label1.Text = "";
            using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    label1.Text = label1.Text + "\n" + line;
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            Path = openFileDialog1.FileName;
            // читаем файл в строку
            using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    label1.Text = label1.Text + "\n" + line;
                }
            }
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }
    }
}
