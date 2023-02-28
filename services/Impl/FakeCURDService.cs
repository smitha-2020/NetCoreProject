using System.Collections.Concurrent;
using project.DTOs;
using project.Models;
using project.services;
using project.Services.Interface;

public class FakeCURDService : BaseEntity, ICURDService
{
  private ConcurrentDictionary<int, Product> _items = new();
  private int _id;

  public Product Create(DTOProduct newData)
  {
    var item = new Product
    {
      Id = Interlocked.Increment(ref _id)
    };
    newData.UpdateModel(item);
    _items[item.Id] = item;
    return item;
  }

  public bool Delete(int id)
  {
    if (_items.ContainsKey(id) && _items.TryRemove(id, out Product? value))
    {
      return true;
    }
    return false;
  }

  public Product Get(int id)
  {
    return _items[id];
  }

  public ICollection<Product> GetAll()
  {
    return _items.Values;
  }

  public Product Update(int id, DTOProduct updateData)
  {
    var dataToUpdate = Get(id);
    updateData.UpdateModel(dataToUpdate);
    dataToUpdate.updatedAt = DateTime.Now;
    return dataToUpdate;
  }
}