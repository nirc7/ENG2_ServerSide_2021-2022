using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{


   public static class DBServices
    {
        static DataSet ds;
        static DataTable dtUsers;
        static SqlDataAdapter adptr;

        public static List<User> GetAllUsers()
        {
            string conStr = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBUsers;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            adptr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
            ds = new DataSet();
            ds.Clear();
            adptr.Fill(ds, "Users");
            dtUsers = ds.Tables["Users"];

            List<User> users = new List<User>();
            foreach (DataRow userRow in dtUsers.Rows)
            {
                users.Add(new User()
                {
                    ID = (int)userRow["ID"],
                    Name = (string)userRow["Name"],
                    Family = (string)userRow["Family"]
                });
            }

            return users;
        }

        internal static void UpdateDB()
        {
            new SqlCommandBuilder(adptr);
            adptr.Update(dtUsers);
        }

        internal static DataTable InsertUser(string name, string fam)
        {
            DataRow dr = dtUsers.NewRow();
            dr["ID"] = 7;
            dr["Name"] = name;
            dr["Family"] = fam;

            dtUsers.Rows.Add(dr);

            return dtUsers;
        }

        internal static DataTable UpdateUser(int id, string name, string fam)
        {
            foreach (DataRow row in dtUsers.Rows)
            {
                if (row.RowState != DataRowState.Deleted && (int)row["ID"] == id)
                {
                    row["Name"] = name;
                    row["Family"] = fam;
                }
            }
            return dtUsers;
        }

        internal static DataTable DeleteUser(int id)
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
                if (dtUsers.Rows[i].RowState != DataRowState.Deleted && (int)dtUsers.Rows[i]["ID"] == id)
                {
                    dtUsers.Rows[i].Delete();
                    i--;
                }
            }
            return dtUsers;
        }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
    }
}
