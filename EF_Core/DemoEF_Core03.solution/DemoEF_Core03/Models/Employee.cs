using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Core03.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
        public double Salary { get; set; }
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }


        public override string ToString()
        {
            return $"Employee: ID = {Id}, Name = {Name}";
        }
    }
}
