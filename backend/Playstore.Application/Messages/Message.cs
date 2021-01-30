using System;

namespace Playstore.Application.Messages
{
    public abstract class Message
    {
        #region Public Properties

        public Guid AggregateId { get; protected set; }
        public string MessageType { get; protected set; }

        #endregion

        #region Constructor

        public Message() => MessageType = GetType().Name;

        #endregion
    }
}