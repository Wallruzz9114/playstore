using System;

namespace Playstore.Application.Messages
{
    public class DomainEvent : Event
    {
        #region Constructors

        public DomainEvent(Guid aggregateId) => AggregateId = aggregateId;

        #endregion
    }
}