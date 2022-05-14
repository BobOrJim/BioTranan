using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Create
        Task<bool> AddAsync(T entity);

        //Read
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        
        //Update
        Task<bool> UpdateAsync(T entity);

        //Delete
        Task<bool> DeleteAsync(Guid id);
    }
}
