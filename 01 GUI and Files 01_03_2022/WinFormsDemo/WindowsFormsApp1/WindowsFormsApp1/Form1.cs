using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string name;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            string name= txtName.Text;
            name = "Hello " + name;
            lblResult.Text = name;
        }

        private void cmbNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResult.Text = cmbNumbers.SelectedIndex + ", " + cmbNumbers.SelectedItem;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            name = txtName.Text; 
        }
    }
}
