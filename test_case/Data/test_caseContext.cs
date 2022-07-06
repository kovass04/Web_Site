using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_case.Models;

namespace test_case.Data
{
    public class test_caseContext : DbContext
    {
        public test_caseContext (DbContextOptions<test_caseContext> options)
            : base(options)
        {
        }

        public DbSet<test_case.Models.Test>? Test { get; set; }
        public DbSet<test_case.Models.Sushi>? Sushi { get; set;}
        public DbSet<test_case.Models.Wok>? Wok { get; set;}
        public DbSet<test_case.Models.Menu>? Menu { get; set; }
        public DbSet<test_case.Models.Roll>? Roll { get; set; }
    }
}
