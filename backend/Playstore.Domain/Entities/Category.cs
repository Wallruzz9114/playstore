using System.Collections.Generic;
using Playstore.Domain.Abstractions;

namespace Playstore.Domain.Entities
{
    public class Category : Entity
    {
        #region Public Properties

        public string Name { get; private set; }
        public int Code { get; private set; }
        public virtual ICollection<Product> Products { get; set; }

        #endregion

        #region Constructors

        public Category(string nome, int codigo)
        {
            Name = nome;
            Code = codigo;

            Validate();
        }

        #endregion

        #region Overriden Methods

        public override string ToString() => $"{ Name } - { Code }";

        #endregion

        #region Public Methods

        public void Validate()
        {
            Validations.ValidateNotEmpty(Name, "The category name cannot be empty.");
            Validations.ValidateIsNot(Code, 0, "The Code cannot be 0");
        }

        #endregion
    }
}