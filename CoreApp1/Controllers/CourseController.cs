﻿using System;
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
    public class CourseController : ControllerBase
    {
        IService<Course, int> courseService;
        public CourseController(IService<Course,int> courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var courses = courseService.GetAsync().Result;
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var courses = courseService.GetAsync(id).Result;
            return Ok(courses);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Course course)
        {
            if(ModelState.IsValid)
            {
                var courses = courseService.CreateAsync(course).Result;
                return Ok(courses);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Course course)
        {
            var courses = courseService.UpdateAsync(id,course).Result;
            return Ok(courses);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = courseService.DeleteAsync(id).Result;
            return Ok(result);
        }
    }
}