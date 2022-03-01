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

namespace FilesandDirectories
{
    public partial class Form1 : Form
    {
        string path = "../../MyFiles/MyData.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWirte_Click(object sender, EventArgs e)
        {
            File.AppendAllText(path, "hello dudi " + new Random().Next(100) + "\n");
            GetAllData();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            label1.Text = File.ReadAllText(path);
        }

        private void btnReadLines_Click(object sender, EventArgs e)
        {
            GetAllData();
        }

        private void GetAllData()
        {
            int count = 1;
            label1.Text = "";
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                label1.Text += count++ + " -- " + line + "\n";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllData();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            GetAllData();
        }
    }
}
