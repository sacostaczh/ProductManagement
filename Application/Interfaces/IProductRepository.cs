using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        //void Update(Product product); //Marca la entidad como modificada.
        //Task<Guid> AddAsync(Product product);
        Task AddAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        //Task UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);

        //Task<Product> GetByIdAsyncReview(Guid id);
        //Task SaveAsyncReview(Product product);

        Task ReloadAsync(Product product);
    }
}
