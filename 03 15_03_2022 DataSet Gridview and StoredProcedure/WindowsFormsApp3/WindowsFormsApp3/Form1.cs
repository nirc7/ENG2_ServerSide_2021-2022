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
        DataTable dtUsers;
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
            string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            adptr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
            ds = new DataSet();
            ds.Clear();
            adptr.Fill(ds, "Users");
            dtUsers = ds.Tables["Users"];
            dataGridView1.DataSource = dtUsers;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = dtUsers.NewRow();
            dr["ID"] = 7;
            dr["Name"] = txtName.Text;
            dr["Family"] = txtFamily.Text;

            dtUsers.Rows.Add(dr);
        }

        private void btnDBfromDT_Click(object sender, EventArgs e)
        {
            new SqlCommandBuilder(adptr);
            adptr.Update(dtUsers);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtUsers.Rows)
            {
                if (row.RowState != DataRowState.Deleted  && row["ID"].ToString() == txtId.Text)
                {
                    row["Name"] = txtName.Text;
                    row["Family"] = txtFamily.Text;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //opt1
            //foreach (DataRow row in dtUsers.Rows)
            //{
            //    if (row.RowState != DataRowState.Deleted && row["ID"].ToString() == txtId.Text)
            //    {
            //        row.Delete();
            //    }
            //}

            //opt2
            for (int i = 0; i < dtUsers.Rows.Count; i++)
            {
                if (dtUsers.Rows[i].RowState != DataRowState.Deleted && dtUsers.Rows[i]["ID"].ToString() == txtId.Text)
                {
                    dtUsers.Rows[i].Delete();
                    i--;
                }
            }
            
        }
    }
}
