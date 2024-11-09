using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            //return await _context.Products.ToListAsync();
            return await _context.Products.Include(p => p.Reviews).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            //return await _context.Products.FindAsync(id);
            return await _context.Products.Include(p => p.Reviews).FirstOrDefaultAsync(p => p.Id == id);
        }
        //public async Task<Product> GetByIdAsync(Guid productId)
        //{
        //    return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        //}

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        //public async Task<Guid> AddAsync(Product product)
        public async Task AddAsync(Product product)
        {
            //product.Id = Guid.NewGuid();
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            //return product.Id;

        }

        public async Task<bool> UpdateAsync(Product product)
        {
            //Update(product);
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }


        //public async Task<bool> UpdateAsync(Product product)
        //{
        //    try
        //    {
        //        _context.Products.Update(product);
        //        await _context.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        // Captura la excepción de concurrencia y maneja el conflicto
        //        var entry = ex.Entries.Single();
        //        var clientValues = (Product)entry.Entity;
        //        var databaseValues = (Product)entry.GetDatabaseValues().ToObject();

        //        // Lógica para resolver el conflicto: puede ser sobreescribir, combinar cambios, etc.
        //        // Por ejemplo, podemos optar por devolver false si detectamos un conflicto
        //        return false;
        //    }
        //}





        //public async Task<bool> UpdateAsync(Product product)
        //{
        //    var existingProduct = await _context.Products.FindAsync(product.Id);
        //    if (existingProduct == null)
        //    {
        //        throw new InvalidOperationException("El producto no existe.");
        //    }

        //    // Aquí puedes comparar el producto cargado con el producto actualizado
        //    // Si hay un conflicto, puedes decidir qué hacer (rechazar, actualizar, etc.)

        //    _context.Entry(existingProduct).CurrentValues.SetValues(product);
        //    await _context.SaveChangesAsync();

        //    return await _context.SaveChangesAsync() > 0;
        //}

        public async Task<bool> DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        //public async Task<Product> GetByIdAsyncReview(Guid id)
        //{
        //    return await _context.Products
        //        .Include(p => p.Reviews)  // Asegúrate de incluir las reseñas si las necesitas
        //        .FirstOrDefaultAsync(p => p.Id == id);
        //}

        //public async Task SaveAsyncReview(Product product)
        //{
        //    _context.Products.Update(product);
        //    await _context.SaveChangesAsync();
        //}


        public async Task ReloadAsync(Product product)
        {
            _context.Entry(product).Reload();
        }
    }
}
