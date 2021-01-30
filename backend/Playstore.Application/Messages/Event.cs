using System;
using MediatR;

namespace Playstore.Application.Messages
{
    public class Event : Message, INotification
    {
        #region Public Properties

        public DateTime Timestamp { get; private set; }

        #endregion

        #region Constructor

        public Event() => Timestamp = DateTime.Now;

        #endregion
    }
}