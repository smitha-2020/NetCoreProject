using Microsoft.EntityFrameworkCore;

namespace project.DB;

using project.Models;

public class AppDBContext : DbContext
{
  private readonly IConfiguration _config;
  public AppDBContext(IConfiguration config){
    _config = config;
  }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
        
        var dbConn = _config.GetConnectionString("DefaultConnection");
        optionsBuilder
        .UseNpgsql(dbConn)
        .UseSnakeCaseNamingConvention();
  
      } 
      public DbSet<Course> Courses { get; set; }

}