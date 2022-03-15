using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{


    static class DBServices
    {
        static DataSet ds;
        static DataTable dtUsers;
        static SqlDataAdapter adptr;

        public static DataTable GetAllUsers()
        {
            string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            adptr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
            ds = new DataSet();
            ds.Clear();
            adptr.Fill(ds, "Users");
            dtUsers = ds.Tables["Users"];
            return dtUsers;
        }
    }
}
