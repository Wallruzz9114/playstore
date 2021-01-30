using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Playstore.Domain.Entities;

namespace Playstore.Domain.Abstractions
{
    public interface IProductRepository : IRepository<Product>
    {
        #region IProductRepository Members

        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> GetByCategory(int code);
        Task<IEnumerable<Category>> GetCategories();

        void AddProduct(Product product);
        void UpdateProduct(Product product);

        void AddCategory(Category category);
        void UpdateCategory(Category category);

        #endregion
    }
}