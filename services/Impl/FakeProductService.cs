namespace project.services.Impl;

using System.Collections.Generic;
using project.DTOs;
using project.Models;
using project.services;


public class FakeProductService : FakeCURDServiceOld<Product, DTOProduct>, IProductService
{
  public async Task<ICollection<Product>> GetAllProductsByCostAsc()
  {
    return await Task.Run(()=>_items.Values.OrderBy(item => item.Title).ToList());
  }
}