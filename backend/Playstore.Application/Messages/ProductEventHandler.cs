using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Playstore.Application.Events;
using Playstore.Domain.Abstractions;

namespace Playstore.Application.Messages
{
    public class ProductEventHandler : INotificationHandler<ProductOutOfStockEvent>
    {
        #region Private Read-Only Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructors

        public ProductEventHandler(IProductRepository productRepository) =>
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        #endregion

        #region INotificationHandler Members

        public async Task Handle(ProductOutOfStockEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(notification.AggregateId);

            // Create a purchase request
            Console.WriteLine(product);
        }

        #endregion
    }
}