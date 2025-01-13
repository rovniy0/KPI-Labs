using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories.Impl;

public abstract class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly DbContext context;
    private readonly DbSet<T> _set;

    public BaseRepository(DbContext context)
    {
        this.context = context;
        _set = context.Set<T>();
    }

    public void Create(T item)
    {
        _set.Add(item);
    }

    public void Delete(int id)
    {
        var item = Get(id);
        if (item == null)
        {
            throw new KeyNotFoundException($"Entity with id {id} not found.");
        }
        _set.Remove(item);
    }

    public IEnumerable<T> Find(
        Expression<Func<T, bool>> predicate,
        int pageNumber = 0,
        int pageSize = 10)
    {
        return _set.Where(predicate)
                   .Skip(pageSize * pageNumber)
                   .Take(pageSize)
                   .ToList();
    }

    public T Get(int id)
    {
        return _set.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _set.ToList();
    }

    public void Update(T item)
    {
        context.Entry(item).State = EntityState.Modified;
    }

    public int Count(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null
            ? _set.Count()
            : _set.Count(predicate);
    }

}
