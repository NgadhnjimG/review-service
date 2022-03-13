using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewService.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<StarReview> StarReview { get; set; }

    }
}
