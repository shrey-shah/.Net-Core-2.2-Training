using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The Entity class type</typeparam>
    /// <typeparam name="TPk">Always an input parameter</typeparam>
    /// Where condition is generic constraint
    public interface IService<TEntity, in TPk> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<bool> DeleteAsync(TPk id);
    }
}
