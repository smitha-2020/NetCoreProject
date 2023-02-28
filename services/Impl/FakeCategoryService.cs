namespace project.services.Impl;

using System.Collections.Generic;
using project.DTOs;
using project.Models;

public class FakeCategoryService : FakeCURDServiceOld<Category, DTOCategory>, ICategoryService
{
  public Task<ICollection<Category>> GetByNameOrder()
  {
    throw new NotImplementedException();
  }
}

