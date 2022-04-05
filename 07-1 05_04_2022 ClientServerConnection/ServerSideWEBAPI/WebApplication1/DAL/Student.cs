using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Student
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id}, {(Name!=null ? Name : "no name")}, {Email}, {Password}";
        }
    }
}