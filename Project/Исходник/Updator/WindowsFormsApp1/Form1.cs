using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinFormsApp1;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WinFormsApp1.Version V = new WinFormsApp1.Version();
        WinFormsApp1.Version V2;
        XmlSerializer formatter = new XmlSerializer(typeof(WinFormsApp1.Version));
        public Form1()
        {
            InitializeComponent();
            try
            {

                CheckVersion("ftp://192.168.0.25/Public/1/try/Version.xml");

                using (FileStream fs = new FileStream("NewVersion.xml", FileMode.OpenOrCreate))
                {
                    V2 = (WinFormsApp1.Version)formatter.Deserialize(fs);
                              label1.Text = "new Version" + V2.version;
                }
            }
            catch (Exception E)
            {

                       label1.Text = E.Message;
                Process.Start("WinFormsApp3.exe");
                Process.GetCurrentProcess().Kill();
            }
            try
            {
                using (FileStream fs = new FileStream("Version.xml", FileMode.OpenOrCreate))
                {
                    V = (WinFormsApp1.Version)formatter.Deserialize(fs);
                     label2.Text = "old Version" + V.version;
                }
            }
            catch (Exception E)
            {
                label2.Text = E.Message;
                Process.Start("WinFormsApp3.exe");
                Process.GetCurrentProcess().Kill();
            }

            if (V.version == V2.version)
            {
                Process.Start("WinFormsApp3.exe");
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                string path = Application.StartupPath;
                string subpath = "old";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory(subpath);

                string[] dirs = Directory.GetDirectories(path + "//" + subpath);
                DirectoryInfo dirInfo2 = new DirectoryInfo(path + "//" + subpath);
                string subpath2 = "oldVersion" + dirs.Length + "-" + V.version;
                dirInfo2.CreateSubdirectory(subpath2);
                string[] files = new string[6] { "WinFormsApp3.deps.json", "WinFormsApp3.dll", "WinFormsApp3.exe", "WinFormsApp3.pdb", "WinFormsApp3.runtimeconfig.dev.json", "WinFormsApp3.runtimeconfig.json" };
                string sourceFile = Application.StartupPath + "\\";
                string destinationFile = path + "//" + subpath + "//" + subpath2 + "\\";
                for (int i = 0; i < 6; i++)
                {
                    string sourceFile1= sourceFile +files[i] ;
                    string destinationFile1 = destinationFile   + files[i];
                    System.IO.File.Copy(sourceFile1, destinationFile1, true);
                }
                WebClient w = new WebClient();
                w.Credentials = new NetworkCredential("ftpuser", "ftppassword");
                string adres = Application.StartupPath+"\\";
                string Path = "ftp://192.168.0.25/Public/1/try/";
                for (int i = 0; i < 6; i++)
                {
                    string newPath = Path + files[i];
                    string newadres = adres+ files[i];
                    w.DownloadFile(new Uri(newPath), newadres);
                }
            }
            Process.Start("WinFormsApp3.exe");
            Process.GetCurrentProcess().Kill();
        }
        public void CheckVersion(string Path)
        {
            WebClient w = new WebClient();
            string adres = Application.StartupPath;
            adres += "\\NewVersion.xml";
            w.Credentials = new NetworkCredential("ftpuser", "ftppassword");
            w.DownloadFile(new Uri(Path), adres);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
