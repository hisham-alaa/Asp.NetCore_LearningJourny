using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Student
    {

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }

        [InverseProperty("Students")]
        public Department StudentDepartment { get; set; }

        [InverseProperty("Student")]
        public ICollection<StudentCourse> StudentCourse { get; set; }=new HashSet<StudentCourse>();

    }
}
