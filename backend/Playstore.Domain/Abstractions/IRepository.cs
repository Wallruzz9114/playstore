using System;

namespace Playstore.Domain.Abstractions
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        #region IRepository Members

        IUnitOfWork UnitOfWork { get; }

        #endregion
    }
}