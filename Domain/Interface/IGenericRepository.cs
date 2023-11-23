using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interface;
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetById(int id);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Update(T entity);
    void Delete(T entity);
    void Add(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void AddRange(IEnumerable<T> entities);

}