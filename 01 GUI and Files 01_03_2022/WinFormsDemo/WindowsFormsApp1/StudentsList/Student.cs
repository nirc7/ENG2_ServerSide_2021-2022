using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsList
{
    class Student
    {
        //Fields:
        string name;

        //Properties:
        public string Name { get; set; }
        public int Grade { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Grade}";
        }
    }
}
