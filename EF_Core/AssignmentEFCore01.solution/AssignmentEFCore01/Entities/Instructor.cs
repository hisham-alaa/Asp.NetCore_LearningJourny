using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "double")]
        public double Bonus { get; set; }
        [Column(TypeName ="money")]
        public double Salary { get; set; }

        public string Address { get; set; }

        public double HourRate { get; set; }

        public Department Department { get; set; }

    }
}
