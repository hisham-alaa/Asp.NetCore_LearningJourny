using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore01.Entities
{
    ///Imagine it as a class in dll 
    class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MgrId { get; set;}
        public DateTime DateOfCreation { get; set; }

        [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();  
        ///The Default for the navigation property is one relation ship

    }
}