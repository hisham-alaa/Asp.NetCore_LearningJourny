using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> courses = new List<Course>();



    }
}
