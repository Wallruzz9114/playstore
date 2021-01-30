using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Playstore.Domain.Abstractions;
using Playstore.Domain.Entities;

namespace Playstore.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Private Read-Only Fields

        private readonly DatabaseContext _databaseContext;

        #endregion

        #region Constructor

        public ProductRepository(DatabaseContext databaseContext) =>
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));

        #endregion

        #region IProductRepository Members

        public IUnitOfWork UnitOfWork => _databaseContext;

        public void AddCategory(Category category) => _databaseContext.Categories.Add(category);

        public void AddProduct(Product product) => _databaseContext.Products.Add(product);

        public async Task<IEnumerable<Product>> GetAll() =>
            await _databaseContext.Products.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Product>> GetByCategory(int code) =>
            await _databaseContext.Products
                .AsNoTracking()
                .Include(i => i.Category)
                .Where(p => p.Category.Code == code)
                .ToListAsync();

        public async Task<Product> GetById(Guid id) =>
            await _databaseContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Category>> GetCategories() =>
            await _databaseContext.Categories.AsNoTracking().ToListAsync();

        public void UpdateCategory(Category category) => _databaseContext.Categories.Update(category);

        public void UpdateProduct(Product product) => _databaseContext.Products.Update(product);

        public void Dispose() => _databaseContext?.Dispose();

        #endregion
    }
}