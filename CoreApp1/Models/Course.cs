using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Models
{
    public class Course
    {
        [Key]
        public int CourseRowId { get; set; }
        [Required(ErrorMessage ="Course Id is Required.")]
        public string CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is Required.")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Capacity is Required.")]
        public int Capacity { get; set; }
    }

}
