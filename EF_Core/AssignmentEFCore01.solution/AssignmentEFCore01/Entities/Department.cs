using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HiringDate { get; set; }

        //[InverseProperty("Students")]
        //public Instructor Manager { get; set; }
        
        [InverseProperty("StudentDepartment")]
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        [InverseProperty("InstructorDepartment")]
        public ICollection<Instructor> Instructors { get; set; }= new HashSet<Instructor>();


    }
}
