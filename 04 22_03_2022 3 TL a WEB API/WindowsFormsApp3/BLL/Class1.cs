using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    static public class BLLServices
    {

        public static List<User> GetAllUsers(int user)
        {
            //Roles[] roles = DBServices.GetRoles4Userid(user);
            //if (roles == roles.Manager)
            //{

            //}
            List<User> users = DBServices.GetAllUsers();
            return users;
        }
    }


   
}
