using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApp1.Models;
using CoreApp1.Services;
using CoreApp1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace CoreApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseStudentController : ControllerBase
    {
        IService<Student, int> studentService;
        IService<Course, int> courseService;

        public CourseStudentController(IService<Student, int> studentService, IService<Course, int> courseService)
        {
            this.studentService = studentService;
            this.courseService = courseService;
        }
       //sample data
      /* {"Course":{
"courseId":"c2",
"courseName":"n2",
"capacity":15
},
"Students": [{"studentId":"shrey","studentName":"n1","address":"aa","city":"aa","state":"aa","courseRowId":1,"course":null},{"studentId":"shrey2","studentName":"qwww","address":"50","city":"50","state":"50","courseRowId":1,"course":null}]
} */
        [HttpPost]
        public IActionResult Post(CourseStudent courseStudent)
        {
            var course = courseService.CreateAsync(courseStudent.Course).Result;

            var students = courseStudent.Students;
            if(students.Count() > 0)
            {
                foreach(var s in students)
                {
                    s.StudentRowId = 0;
                    var student = studentService.CreateAsync(s).Result;
                }
            }
            return Ok(new CourseStudent {
                Course = course,
                Students = students
            });
        }
    }
}