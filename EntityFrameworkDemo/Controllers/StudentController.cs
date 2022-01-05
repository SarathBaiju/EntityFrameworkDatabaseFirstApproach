using EntityFrameworkDemo.Database;
using EntityFrameworkDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this._studentDbContext = studentDbContext;
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_studentDbContext.Students.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                _studentDbContext.Students.Add(student);
                _studentDbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("add-many")]
        public IActionResult AddStudent([FromBody] IEnumerable<Student> students)
        {
            try
            {
                _studentDbContext.Students.AddRange(students);
                _studentDbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("update")]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            try
            {
                _studentDbContext.Students.Update(student);
                _studentDbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var student = _studentDbContext.Students.Find(id);
                _studentDbContext.Students.Remove(student);
                _studentDbContext.SaveChanges();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
