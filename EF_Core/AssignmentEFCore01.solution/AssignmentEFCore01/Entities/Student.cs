using System;
using System.Collections.Generic;
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
        public Department Department { get; set; }


    }
}
