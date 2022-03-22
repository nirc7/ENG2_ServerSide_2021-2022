using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    static public class StudentsDBMOCK
    {
        public static List<Student> students = new List<Student>() {
            new Student(){ID=1, Name="avi", Grade=97 },
            new Student(){ID=3, Name="benny", Grade=77 },
            new Student(){ID=2, Name="Hezi", Grade=88 },
            new Student(){ID=4, Name="charlie", Grade=99 },
        };
    }
}