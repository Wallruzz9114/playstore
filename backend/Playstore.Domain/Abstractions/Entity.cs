using System;

namespace Playstore.Domain.Abstractions
{
    public class Entity
    {
        #region Public Properties

        public Guid Id { get; set; }

        #endregion

        #region Contructor

        protected Entity() => Id = Guid.NewGuid();

        #endregion

        #region Overriden Methods

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(this, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{ GetType().Name } [Id={ Id }]";

        #endregion

        #region Operator Methods

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        #endregion
    }
}