using Microsoft.EntityFrameworkCore;
using project.Models;
using Npgsql;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace project.DB;

public class AppDBContext :
IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    // Static constructor which will be run ONCE
    static AppDBContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Course.CourseStatus>();
        // You can also do that automatically using Reflection

        // Use the legacy timestamp behaviour - check Npgsql for more details
        // Recommendation from Postgres: Don't use time zone in database
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    private readonly IConfiguration _config;

    public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration config) : base(options) => _config = config;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var dbConn = _config.GetConnectionString("DefaultConnection");
        optionsBuilder
        .UseNpgsql(dbConn)
        .AddInterceptors(new AppDBContextInterceptor())
        .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Mapping enum to postgres
        // modelBuilder.HasPostgresEnum<Course.CourseStatus>();
        //created using FluentAPI-Adding index to a particular column
        //modelBuilder.Entity<Course>()
        //          .HasIndex(item => item.Name);

        // modelBuilder.Entity<Category>()
        // .HasRequired<>(s => s.CurrentGrade)
        // .WithMany(g => g.Students)
        // .HasForeignKey<int>(s => s.CurrentGradeId);

        //AutoInclude
        modelBuilder.Entity<Product>().Navigation(x => x.Category).AutoInclude();

        modelBuilder.AddIdentityConfig();
    }

    //public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categorys { get; set; } = null!;

}