using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApprovalRequest.Application.Interfaces.Repositories;
public interface IBaseRepository<T> where T : class
{
    Task<T> AddAsync(T entity);

    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>> GetAllAsync();

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}