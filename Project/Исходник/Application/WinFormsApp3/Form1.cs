using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WinFormsApp3
{
   
    public partial class Form1 : Form
    {
        Version V = new Version(14);
        Version V2;
        string path;
        List<Data> A = new List<Data>();
        int correct = 0;
        int incorrect = 0;
        int tek = 0;
        Random rnd = new Random();
        XmlSerializer formatter = new XmlSerializer(typeof(Version));
        public Form1()
        {
            InitializeComponent();

            try
            {
                using (FileStream fs = new FileStream("Version.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, V);
                    label6.Text = "Version - " + Convert.ToString(V.version);
                }
            }
            catch (Exception E)
            {
            }
            label3.Text = Convert.ToString(correct);
            label4.Text = Convert.ToString(incorrect);
            label1.Text = " ";
            button1.Enabled = false;
            button2.Enabled = false;
            
        }
        

        async public void SetWord()
        {
            if(AllUsed()||correct+incorrect>30)
            {
                MessageBox.Show("Все выполнено");
                button1.Enabled = false;
                button2.Enabled = false;
                return;
            }

            tek = rnd.Next() % A.Count;
            while(A[tek].Used==1)
            {
                tek= rnd.Next() % A.Count;
            }
            label1.Text = A[tek].Word+"        ";
            label1.TextAlign = ContentAlignment.MiddleCenter; 
            button1.Text = A[tek].V1;
            button2.Text = A[tek].V2;
            A[tek].Used = 1;



            await Task.Delay(2000);
            //System.Threading.Thread.Sleep(2000);
            button1.Enabled = true;
            button2.Enabled = true;
            label1.BackColor = Form1.DefaultBackColor;
            this.BackColor = Form1.DefaultBackColor;
        }
        public bool AllUsed()
        {
            foreach (Data Q in A)
            {
                if (Q.Used == 0)
                    return false;

            }
            return true;
        }
        public void TextWork()
        {
           // string path = @"./Texts.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] pr = line.Split('|');
                        A.Add(new Data(pr[0], pr[1], pr[2], Convert.ToInt32(pr[3])));
                        //Console.WriteLine(line);
                    }
                }
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(A[tek].CheckCorrect(1))
            {
                this.BackColor = Color.Green;
                correct++;
                button1.Enabled = false;
                button2.Enabled = false;
                label3.Text = Convert.ToString(correct);
                label4.Text = Convert.ToString(incorrect);

            }
            else
            {
                this.BackColor = Color.Red;
                incorrect++;
                button1.Enabled = false;
                button2.Enabled = false;
                label3.Text = Convert.ToString(correct);
                label4.Text = Convert.ToString(incorrect);


            }

            SetWord();
            button3.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (A[tek].CheckCorrect(2))
            {
                this.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                correct++;
                button1.Enabled = false;
                button2.Enabled = false;
                label3.Text = Convert.ToString(correct);
                label4.Text = Convert.ToString(incorrect);

            }
            else
            {
                this.BackColor = Color.Red;
                label1.BackColor = Color.Red;
                incorrect++;
                button1.Enabled = false;
                button2.Enabled = false;
                label3.Text = Convert.ToString(correct);
                label4.Text = Convert.ToString(incorrect);

            }
            button3.Select();
            SetWord();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            path = openFileDialog1.FileName;
            // читаем файл в строку
            TextWork();
            SetWord();
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
