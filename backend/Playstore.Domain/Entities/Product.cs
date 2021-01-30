using System;
using Playstore.Domain.Abstractions;
using Playstore.Domain.Exceptions;

namespace Playstore.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        #region Public Properties

        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public string Image { get; private set; }
        public int QuantityInStock { get; private set; }
        public Dimensions Dimensions { get; set; }
        public virtual Category Category { get; private set; }

        #endregion

        #region Constructors

        public Product(string name, string description, bool active, decimal value, Guid categoryId, DateTime registrationDate, string image, Dimensions dimensions)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            RegistrationDate = registrationDate;
            Image = image;
            Dimensions = dimensions;

            Validate();
        }

        #endregion

        #region Public Methods

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void UpdateCategory(Category category)
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void UpdateDescription(string description)
        {
            Validations.ValidateNotEmpty(Description, "The Description field cannot be empty.");
            Description = description;
        }

        public void IncreaseStock(int quantity)
        {
            if (quantity < 0)
                quantity *= -1;

            QuantityInStock -= quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity < 0) quantity *= -1;
            if (!HasEnoughStock(quantity)) throw new DomainException("Not enought stock.");

            QuantityInStock += quantity;
        }

        public bool HasEnoughStock(int quantity)
        {
            if (quantity < 0)
                quantity *= -1;

            return QuantityInStock >= quantity;
        }

        public void Validate()
        {
            Validations.ValidateNotEmpty(Name, "The product name field cannot be empty.");
            Validations.ValidateNotEmpty(Description, "The product description field cannot be empty.");
            Validations.ValidateIs(CategoryId, Guid.Empty, "The product category id cannot be empty.");
            Validations.ValidateDecimalMinimum(Value, 0, "The product value should be > 0.");
            Validations.ValidateNotEmpty(Image, "The image field cannot be empty.");
        }

        #endregion
    }
}