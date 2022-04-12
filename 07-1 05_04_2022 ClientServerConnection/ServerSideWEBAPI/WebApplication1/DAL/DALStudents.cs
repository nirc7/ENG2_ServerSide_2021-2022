using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DALStudents
    {
        static string strCon = @"Data Source=LAB-M00\SQLLAB;Initial Catalog=DBStudents;Integrated Security=True";
        static SqlConnection con;

        static DALStudents()
        {
            con = new SqlConnection(strCon);
        }

        public static Student Login(StudentLoginDetail value)
        {
            SqlDataReader reader = null;
            try
            {
                string comm =
                    $" SELECT * FROM TBStudents " +
                    $" WHERE Email='{value.Email}' and Password= '{value.Password}'";
                reader = ExcNQ(comm);
                if (reader.Read())
                {
                    return new Student()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Email = (string)reader["Email"],
                        Password = (string)reader["Password"]
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                new InvalidOperationException("error in ExcNQ DAL " + ex.Message);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            return null;
        }

        public static SqlDataReader ExcNQ(string command)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand comm = new SqlCommand(command, con);
                con.Open();
                reader = comm.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                new InvalidOperationException("error in ExcNQ DAL " + ex.Message);
            }
            return reader;
        }
    }
}
