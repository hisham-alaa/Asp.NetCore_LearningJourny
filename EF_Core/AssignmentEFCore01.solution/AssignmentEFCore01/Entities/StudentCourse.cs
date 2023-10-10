using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class StudentCourse
    {

        public int StudentId { get; set;}
        public int CourseId { get; set;}
        public double Grade { get; set; }

        [InverseProperty("StudentCourse")]
        public Student Student { get; set; }
        [InverseProperty("CourseStudent")]
        public Course Course { get; set; }

    }
}
