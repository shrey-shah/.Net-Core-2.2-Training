using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp1.Models;
using CoreApp1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IService<Student, int> studentService;
        public StudentController(IService<Student, int> studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var students = studentService.GetAsync().Result;
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var students = studentService.GetAsync(id).Result;
            return Ok(students);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Student student)
        {
            var students = studentService.CreateAsync(student).Result;
            return Ok(students);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var students = studentService.UpdateAsync(id, student).Result;
            return Ok(students);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = studentService.DeleteAsync(id).Result;
            return Ok(result);
        }
    }
}