using Microsoft.EntityFrameworkCore;
using ReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewService
{
    public class KomentDBContext: DbContext
    {
        public KomentDBContext(DbContextOptions<KomentDBContext> options ) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<StarReview> StarReview { get; set; }

    }
}
