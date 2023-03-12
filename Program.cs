
using project.services;
using project.services.Impl;
using System.Text.Json.Serialization;
using project.Models;
using project.DTOs;
using project.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add  database services to the container.
builder.Services.AddDbContext<AppDBContext>();

builder.Services
.AddControllers()
.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register the services for dependency injection create a WeatherForecastService object of type IWeatherForecast
//                               type           object from which instance will be created.
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<IProductService, DbProductService>();
builder.Services.AddScoped<ICategoryService, DbCategoryService>();
builder.Services.AddScoped<IUserservice, DBUserService>();
builder.Services.AddScoped<IRoleService, DBRoleService>();
//builder.Services.AddSingleton<ICURDService<Course,CourseDTO>,FakeCURDService<Course,CourseDTO>>();
// builder.Services.AddSingleton<IStudentService,FakeStudentService>();
//builder.Services.AddSingleton<ICURDServiceCOPY<Product,DTOProduct>, FakeCURDServiceOld<Product,DTOProduct>>();

//builder.Services.AddSingleton<ICourseService, FakeCourseSeriveCOPY>();

builder.Services
    .AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AppDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
  using (var scope = app.Services.CreateScope())
  {
    var dbContext = scope.ServiceProvider.GetService<AppDBContext>();

    if (dbContext is not null)
    {
      dbContext.Database.EnsureDeleted();
      dbContext.Database.EnsureCreated();
    }
  }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
