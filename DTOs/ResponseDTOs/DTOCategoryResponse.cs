using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using project.Models;

namespace project.DTOs;

public class DTOCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Image { get; set; } = null!;
}

