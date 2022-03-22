using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        DataSet ds;
        List<User> dtUsers;
        SqlDataAdapter adptr;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFillDT_Click(object sender, EventArgs e)
        {
            dtUsers = BLLServices.GetAllUsers(7);
            dataGridView1.DataSource = dtUsers;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
          //  dtUsers = DBServices.InsertUser(txtName.Text, txtFamily.Text);
            dataGridView1.DataSource = dtUsers;
        }

        private void btnDBfromDT_Click(object sender, EventArgs e)
        {
           // DBServices.UpdateDB();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           // dtUsers = DBServices.UpdateUser(int.Parse(txtId.Text), txtName.Text, txtFamily.Text);
            dataGridView1.DataSource = dtUsers;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //dtUsers = DBServices.DeleteUser(int.Parse(txtId.Text));
            dataGridView1.DataSource = dtUsers;
        }

        private void btnSPgetFamily_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True");

            SqlCommand MySPCommand = new SqlCommand("SearchUser", myCon);
            MySPCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parFName = new SqlParameter("@FamilyName", SqlDbType.NVarChar, 20);
            parFName.Direction = ParameterDirection.Output;

            SqlParameter parId = new SqlParameter("@MyID", txtId.Text);
            parId.Direction = ParameterDirection.Input;

            SqlParameter parErr = new SqlParameter();
            parErr.Direction = ParameterDirection.ReturnValue;

            MySPCommand.Parameters.Add(parFName);
            MySPCommand.Parameters.Add(parErr);
            MySPCommand.Parameters.Add(parId);

            myCon.Open();
            MySPCommand.ExecuteNonQuery();
            myCon.Close();


            if (parErr.Value.ToString() == "0")
            {
                MessageBox.Show(parFName.Value.ToString());
            }
            else
            {
                MessageBox.Show("ERR:(");
            }
        }

        private void btnSPGetTable_Click(object sender, EventArgs e)
        {
            SqlConnection myCon = new SqlConnection(@"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True");

            SqlCommand MySPCommand = new SqlCommand("SearchUserTable", myCon);
            MySPCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parId = new SqlParameter("@MyID", txtId.Text);
            parId.Direction = ParameterDirection.Input;

            MySPCommand.Parameters.Add(parId);

            SqlDataAdapter adptr = new SqlDataAdapter(MySPCommand);
            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
