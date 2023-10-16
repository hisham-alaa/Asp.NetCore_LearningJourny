using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Department : ModelBase
    {

        [Required(ErrorMessage = "Code Is Required!")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Code Is Required!")]
        [MaxLength(50, ErrorMessage = "Length Must not Exceed 50!")]
        public string Name { get; set; }

        [DisplayName("Date Of Creation")]
        public DateTime DateOfCreation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
