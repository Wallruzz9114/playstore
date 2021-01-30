using System;
using System.Threading.Tasks;
using Playstore.Application.Events;
using Playstore.Application.Interfaces;
using Playstore.Domain.Abstractions;

namespace Playstore.Infrastructure.Implementations
{
    public class ProductService : IProductService
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;
        private readonly IMediatrHandler _mediatrHandler;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository, IMediatrHandler mediatrHandler)
        {
            _mediatrHandler = mediatrHandler ?? throw new ArgumentNullException(nameof(productRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        #endregion

        #region IProductService Members

        public async Task<bool> IncreaseStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null || !product.HasEnoughStock(quantity)) return false;

            product.IncreaseStock(quantity);
            _productRepository.UpdateProduct(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> DecreaseStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null) return false;

            product.DecreaseStock(quantity);

            if (product.QuantityInStock < 10)
                await _mediatrHandler.PublishEvent(new ProductOutOfStockEvent(product.Id, product.QuantityInStock));

            _productRepository.UpdateProduct(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _productRepository?.Dispose();
        }

        #endregion
    }
}