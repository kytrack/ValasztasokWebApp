using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Valasztasok.Models
{
    public class ValasztasDbContext: DbContext
    {
        public ValasztasDbContext(DbContextOptions<ValasztasDbContext>options)
            :base(options)
        { 

        }
        public DbSet<Jelolt> Jelolt { get; set; }
        public DbSet<Part> Partok { get; set; }
    }
}
