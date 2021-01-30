using System.Threading.Tasks;

namespace Playstore.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        #region IUnitOfWork Members

        Task<bool> Commit();

        #endregion
    }
}