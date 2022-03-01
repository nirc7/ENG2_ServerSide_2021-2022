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

namespace StudentsList
{
    public partial class Form1 : Form
    {
        List<Student> ls = new List<Student>();
        string filePath = "MystudentsData.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ls.Add(
                new Student()
                {
                    Name = txtName.Text,
                    Grade = int.Parse(txtGrade.Text)
                }
             );
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.Delete(filePath);
            foreach (var stu in ls)
            {
                File.AppendAllText(filePath, stu.ToString() + "\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var line in File.ReadAllLines(filePath))
            {
                string[] data = line.Split('-');
                ls.Add(
                    new Student()
                    { Name = data[0], Grade = int.Parse(data[1]) });
            }


        }
    }
}
