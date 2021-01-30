using System.Threading.Tasks;
using Playstore.Application.Messages;

namespace Playstore.Application.Interfaces
{
    public interface IMediatrHandler
    {
        #region IMediatrHandler Members

        Task PublishEvent<T>(T eventToPublish) where T : Event;

        #endregion
    }
}