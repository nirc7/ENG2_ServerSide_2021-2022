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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ExecNQ(
                $" INSERT INTO " +
                $" TBUsers(Name, Family) " +
                $" VALUES('{txtName.Text}', '{txtFamily.Text}') ");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ExecNQ(
                $" UPDATE TBUsers " +
                $" SET Name='{txtName.Text}' , Family='{txtFamily.Text}' " +
                $" WHERE Id={txtId.Text}");
        }

        private void ExecNQ(string commStr)
        {
            SqlConnection con=null;
            try
            {
                string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
                con = new SqlConnection(conStr);
                SqlCommand comm = new SqlCommand(commStr, con);

                con.Open();
                int res = comm.ExecuteNonQuery();


                MessageBox.Show(res == 1 ? ":)" : ":(");
                RefreshLabl();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message + "!!!");
                throw new Exception("go to school");
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show("END");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ExecNQ(
                                $" DELETE FROM TBUsers " +
                                $" WHERE Id={txtId.Text}");
            }
            catch (Exception ex2)
            {

                throw;
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            RefreshLabl();
        }

        private void RefreshLabl()
        {
            string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand(
                " SELECT * " +
                " FROM TBUSers " +
                " ORDER BY Name Desc", con);
            lblTable.Text = "";

            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                lblTable.Text += reader["Id"].ToString() + ", " + (string)reader["Name"] + ", " + reader[2] + "\n";
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshLabl();
        }
    }
}
