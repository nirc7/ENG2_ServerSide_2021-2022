using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student
    {
        int id;
        public int ID
        {
            get { return id; }

            set
            {
                if (value < 100)
                {
                    id = value;
                }
                else
                {
                    id = -7;
                }
            }
        }
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(int id)
        {
            ID = 555;
        }


        public Student(string name)
        {
            Name = "no name";
        }
        public Student()
        {

        }
        public override string ToString()
        {
            return $"{ID},{Name},{Grade}";
        }
    }
}