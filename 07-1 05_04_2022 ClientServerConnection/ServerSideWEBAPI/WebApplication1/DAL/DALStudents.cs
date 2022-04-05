using BLL;
using System;
using System.Collections.Generic;
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

            try
            {
                string comm =
                    $" SELECT * FROM TBStudents " +
                    $" WHERE Email='{value.Email}' and Password= '{value.Password}'";
                SqlDataReader reader= ExcNQ(comm);
                if (reader.Read())
                {

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public static SqlDataReader ExcNQ(string command)
        {
            try
            {
                SqlCommand comm = new SqlCommand(command, con);
                con.Open();
                SqlDataReader reader = comm.ExecuteReader();
                return reader;

            }
            catch (Exception e)
            {

            }
            finally 
            {
                con.Close();
            }
        }
    }
}
