using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentsController : ApiController
    {
        public IEnumerable<Student> Get()
        {
            Student[] studentds = StudentsDBMOCK.students.ToArray();
            return studentds;
        }

        public Student Get(int id)
        {
            return StudentsDBMOCK.students.FirstOrDefault(stu=> stu.ID == id);
        }
    }
}
