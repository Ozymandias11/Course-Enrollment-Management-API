using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Course
    {
        public Guid Id { get; set; }    
        public string? Title { get; set; }
        public string? Description { get; set; }    
        public int Credits { get; set; }   
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
