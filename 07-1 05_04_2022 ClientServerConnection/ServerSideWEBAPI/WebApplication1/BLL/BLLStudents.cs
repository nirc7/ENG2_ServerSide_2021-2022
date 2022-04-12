using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLLStudents
    {
        public static Student LoginStudent(StudentLoginDetail value) 
        {
            //code security/ roles / algorithm / 
            return DALStudents.Login(value);
        }
    }
}
