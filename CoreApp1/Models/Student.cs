using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Models
{   
    public class Student
    {
        [Key]
        public int StudentRowId { get; set; }
        [Required(ErrorMessage = "Student Id is Required.")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Student Name is Required.")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Student Address is Required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Student City is Required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Student State is Required.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Course Id is Required.")]
        public int CourseRowId { get; set; }
        public Course Course { get; set; }
    }
}
