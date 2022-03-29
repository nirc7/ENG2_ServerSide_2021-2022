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
            return StudentsDBMock.students.AsEnumerable();
        }

        public Student Get(int id)
        {
            Student stu2Return = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
            return stu2Return;
        }

        public int Post([FromBody] Student value)
        {
            int max = StudentsDBMock.students.Max(stu => stu.ID) + 1;
            value.ID = max;
            StudentsDBMock.students.Add(value);
            return value.ID;
        }

        public string Put(int id, [FromBody] Student value)
        {
            //Student news = new Student(400,value.Name, 123);
            Student stu2Update = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
            stu2Update.Name = value.Name;
            stu2Update.Grade = value.Grade;
            return "done:)";
        }

        public IHttpActionResult Delete(int id)
        {
            Student stu2Delete = StudentsDBMock.students.FirstOrDefault(stu=>stu.ID == id);
            StudentsDBMock.students.Remove(stu2Delete);
            var json = new { Result="delete successfully!" };
            var jRes = Json(json);
            return jRes;
        }
    }
}
