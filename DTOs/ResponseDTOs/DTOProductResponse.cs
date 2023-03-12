namespace project.DTOs;

using System.ComponentModel.DataAnnotations;
using project.Models;

public class DTOProductResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Description { get; set; } = null!;
    public ICollection<string> Images { get; set; } = null!;
    public DTOCategoryResponse Category { get; set; } = null!;

    public static DTOProductResponse ConvertToDTO(Product product)
    {
        return new DTOProductResponse
        {
            Id = product.Id,
            Title = product.Title,
            Price = product.Price,
            Description = product.Description,
            Images = product.Images,
            Category = new DTOCategoryResponse
            {
                Id = product.Category.Id,
                Name = product.Category.Name,
                Image = product.Category.Image
            }
        };

    }
}