using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace test_case.Areas.Identity.Data;

public class test_caseContext : IdentityDbContext<test_caseUser>
{
    public test_caseContext(DbContextOptions<test_caseContext> options)
        : base(options)
    {
    }
    public DbSet<test_case.Models.Test>? Test { get; set; }
    public DbSet<test_case.Models.Sushi>? Sushi { get; set; }
    public DbSet<test_case.Models.Wok>? Wok { get; set; }
    public DbSet<test_case.Models.Menu>? Menu { get; set; }
    public DbSet<test_case.Models.Roll>? Roll { get; set; }
    public DbSet<test_case.Models.Bucket>? Bucket { get; set; }
    public DbSet<test_case.Models.Check>? Check { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
