using System;
using Playstore.Application.Messages;

namespace Playstore.Application.Events
{
    public class ProductOutOfStockEvent : DomainEvent
    {
        #region Public Properties

        public int RemainingQuantity { get; private set; }

        #endregion

        #region Constructors

        public ProductOutOfStockEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId) =>
            RemainingQuantity = quantidadeRestante;

        #endregion
    }
}