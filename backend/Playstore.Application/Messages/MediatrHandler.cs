using System;
using System.Threading.Tasks;
using MediatR;
using Playstore.Application.Interfaces;

namespace Playstore.Application.Messages
{
    public class MediatrHandler : IMediatrHandler
    {
        #region Private Read-Only Fields

        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public MediatrHandler(IMediator mediator) =>
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        #endregion

        #region MediaiteHandler Members

        public async Task PublishEvent<T>(T eventToPublish) where T : Event =>
            await _mediator.Publish(eventToPublish);

        #endregion
    }
}