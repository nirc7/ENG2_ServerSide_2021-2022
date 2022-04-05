using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace WebApplication1.Controllers
{
    public class StudentsController : ApiController
    {
        public IHttpActionResult Post([FromBody] StudentLoginDetail value)
        {
            try
            {
                Student student2Return = BLLStudents.LoginStudent(value);
                if (student2Return == null)
                {
                    return Content(HttpStatusCode.NotFound, $"student with email={value.Email} was not found in DB! "/* + student2Return.ToString()*/);
                }

                return Ok(student2Return);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
