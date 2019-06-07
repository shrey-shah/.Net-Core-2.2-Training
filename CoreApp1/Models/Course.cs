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
        //[Required(ErrorMessage ="Course Id is Required.")]
        public string CourseId { get; set; }
      //  [Required(ErrorMessage = "Course Name is Required.")]
        public string CourseName { get; set; }
     //   [CustomValidatorAttribute(ErrorMessage = "Capacity must be greater than 0.")]
        public int Capacity { get; set; }
    }

    public class CustomValidatorAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(Convert.ToInt32(value) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

}
