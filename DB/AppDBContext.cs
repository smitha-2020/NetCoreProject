using Microsoft.EntityFrameworkCore;

namespace project.DB;

using project.Models;
using Npgsql;

public class AppDBContext : DbContext
{
  private readonly IConfiguration _config;
  public AppDBContext(IConfiguration config)
  {
    _config = config;
  }

  static AppDBContext()
  {
    NpgsqlConnection.GlobalTypeMapper.MapEnum<Course.CourseStatus>();
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var dbConn = _config.GetConnectionString("DefaultConnection");
    optionsBuilder
    .UseNpgsql(dbConn)
    .UseSnakeCaseNamingConvention();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //Mapping enum to postgres
    modelBuilder.HasPostgresEnum<Course.CourseStatus>();
    //created using FluentAPI-Adding index to a particular column
    modelBuilder.Entity<Course>()
                .HasIndex(item => item.Name);
  }

  public DbSet<Course> Courses { get; set; } = null!;
  public DbSet<Product> Products { get; set; } = null!;
  public DbSet<Category> Categorys { get; set; } = null!;

}