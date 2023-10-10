using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Topic")]
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();



    }
}
