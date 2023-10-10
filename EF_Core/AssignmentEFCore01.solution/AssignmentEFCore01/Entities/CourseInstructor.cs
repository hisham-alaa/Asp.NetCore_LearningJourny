using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class CourseInstructor
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }
        public string Evaluate { get; set; }

        [InverseProperty("CourseInstructors")]
        public Course Course { get; set; }
        [InverseProperty("InstructorCourses")]
        public Instructor Instructor { get; set; }
    }
}
