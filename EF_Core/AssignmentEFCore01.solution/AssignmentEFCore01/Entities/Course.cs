using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEFCore01.Entities
{
    class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Duration { get; set; }
        public string? Description { get; set; }
        public Topic Topic { get; set; }

    }
}
