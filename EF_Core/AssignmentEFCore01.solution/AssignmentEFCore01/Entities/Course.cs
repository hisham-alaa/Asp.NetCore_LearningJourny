using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }

        [InverseProperty("Courses")]
        public Topic Topic { get; set; }

        [InverseProperty("Course")]
        public ICollection<StudentCourse> CourseStudent { get; set; }=new HashSet<StudentCourse>();
        
        [InverseProperty("Course")]
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();

    }
}
