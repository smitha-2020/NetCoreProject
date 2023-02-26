using project.DTOs;
using project.Models;
using System.Collections.Concurrent;

namespace project.services.Impl;

public class FakeCURDService<TModel, TDto> : ICURDServiceCOPY<TModel, TDto> 
where TModel : BaseModel, new() 
where TDto:BaseDTO<TModel>
{
  private ConcurrentDictionary<int, TModel> _items = new();
  private int _itemId;
  public TModel? Create(TDto request)
  {
    var item = new TModel
    {
      Id = Interlocked.Increment(ref _itemId),
    };
    request.UpdateModel(item);
    _items[item.Id] = item;
    return item;
  }

  public bool Delete(int id)
  {
    if (!_items.ContainsKey(id))
    {
      return false;
    }
    _items.TryRemove(id, out var result);
    return true;
  }

  public TModel? Get(int id)
  {
    if (_items.TryGetValue(id, out var result))
    {
      return result;
    }
    return null;
  }

  public ICollection<TModel> GetAll()
  {
    return _items.Values;
  }

  public TModel? Update(int id, TDto request)
  {

    var item = Get(id);
    if (item is null)
    {
      return null;
    }
    item.updatedAt = DateTime.Now;
    request.UpdateModel(item);
    _items[item.Id] = item;
    return item;
  }
}