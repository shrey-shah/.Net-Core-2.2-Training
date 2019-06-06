using CoreApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.ViewModels
{
    public class CourseStudent
    {
        public Course Course { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
