using EshopDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopDemo.BLL.Repositories
{
    /// <summary>
    /// Repository for CRUD 
    /// </summary>
    public interface IRepository<T> where T : IEntity
    {
        Task<T> Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();

        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
