using project.DTOs;
using project.Models;

namespace project.AutoMapper;

public static class ProductCategoryExtension
{
  public static Product ProductCategoryMapper(this Product product)
  {
    return new Product
    {
      Id = product.Id,
      Title = product.Title,
      Price = product.Price,
      Description = product.Description,
      Images = product.Images,
      Category = new Category
      {
        Id = product.Category.Id,
        Name = product.Category.Name,
        Image = product.Category.Image
      }
    };
  }
}