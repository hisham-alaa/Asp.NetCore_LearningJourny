using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF_Core03.Models
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string Description { get; set; }
        public DateOnly DateOfCreation { get; set; }

        public ICollection<Employee> Emps { get; set; } = new HashSet<Employee>();


        public override string ToString()
        {
            return $"Department: ID = {Id}, Name = {Name}";
        }
    }
}
