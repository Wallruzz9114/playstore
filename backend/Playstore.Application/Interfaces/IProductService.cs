using System;
using System.Threading.Tasks;

namespace Playstore.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        #region IProductService Members

        Task<bool> IncreaseStock(Guid productId, int quantity);
        Task<bool> DecreaseStock(Guid productId, int quantity);

        #endregion
    }
}