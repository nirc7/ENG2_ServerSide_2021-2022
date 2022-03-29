using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/RWstudents")]
    public class RWStudentsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult LoadStudents()
        {
            try
            {
                //throw new ArithmeticException("go 2 school!");
                return Ok(StudentsDBMock.students);
            }
            catch (Exception e)
            {
                return BadRequest("mashbali " + e.Message);
                //return Content(HttpStatusCode.BadRequest, e);
            }
        }

        //[Route("api/RWstudents/{id}/grade")]
        [Route("{id:int}/grade")]
        [Route("~/g/{id:int}")]
        public IHttpActionResult Getgrades4Student(int id)
        {
            try
            {
                //int.Parse("a");
                Student stu2Find = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Find != null)
                {
                    return Ok(stu2Find.Grade);
                }
                return Content(HttpStatusCode.NotFound, $"student with id={id} was not found in Get!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        [Route("{num:int}")]
        public IHttpActionResult Get(int num)
        {
            try
            {
                //int.Parse("a");
                Student stu2Find = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == num);
                if (stu2Find != null)
                {
                    return Ok(stu2Find);
                }
                return Content(HttpStatusCode.NotFound, $"student with id={num} was not found in Get!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

        [Route("{isAvi:bool}")]
        public IHttpActionResult Get(bool isAvi)
        {
            try
            {
                Student stu2Find = StudentsDBMock.students.FirstOrDefault(
                    stu => isAvi ? stu.Name == "avi" : stu.Name != "avi");

                if (stu2Find != null)
                {
                    return Ok(stu2Find);
                }
                return Content(HttpStatusCode.NotFound, $"student avi was not found in Get!");
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

       
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        //throw new ArithmeticException("go 2 school!");
        //        return Ok(StudentsDBMock.students);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest("mashbali " + e.Message);
        //        //return Content(HttpStatusCode.BadRequest, e);
        //    }
        //}


        //public IHttpActionResult Get(string id)
        //{
        //    try
        //    {
        //        //int.Parse("a");
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return Content(HttpStatusCode.BadRequest, e);
        //    }
        //}



        public IHttpActionResult Post([FromBody] Student value)
        {
            try
            {
                int max = StudentsDBMock.students.Max(stu => stu.ID) + 1;
                value.ID = max;
                StudentsDBMock.students.Add(value);

                return Created(new Uri(Request.RequestUri.AbsoluteUri + value.ID), value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Put(int id, [FromBody] Student value)
        {
            try
            {
                Student stu2Update = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Update == null)
                {
                    return Content(HttpStatusCode.NotFound, $"student with id={id} was not found 4 update!");
                }

                stu2Update.Name = value.Name;
                stu2Update.Grade = value.Grade;
                return Content(HttpStatusCode.OK, stu2Update);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Student stu2Delete = StudentsDBMock.students.FirstOrDefault(stu => stu.ID == id);
                if (stu2Delete == null)
                {
                    return Content(HttpStatusCode.NotFound, $"student with id={id} was not found 4 delete!");
                }
                StudentsDBMock.students.Remove(stu2Delete);
                return Ok();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e);
            }
        }

    }
}
