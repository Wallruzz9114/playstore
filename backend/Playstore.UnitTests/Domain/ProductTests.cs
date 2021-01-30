using System;
using Playstore.Domain.Abstractions;
using Playstore.Domain.Entities;
using Playstore.Domain.Exceptions;
using Xunit;

namespace Playstore.UnitTests.Domain
{
    public class ProductTests
    {
        [Fact]
        public void MustReturnExceptions()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Product(string.Empty, "Description", false, 100, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal("The product name cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", string.Empty, false, 100, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal("The product description cannot be empty.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 0, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal("The product value must be > 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.Empty, DateTime.Now, "Image", new Dimensions(1, 1, 1))
            );
            Assert.Equal("The product category id cannot be empty", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.NewGuid(), DateTime.Now, string.Empty, new Dimensions(1, 1, 1))
            );
            Assert.Equal("The product image cannot be empty", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(0, 1, 1))
            );
            Assert.Equal("The product length must be > 0", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(1, 0, 1))
            );
            Assert.Equal("The product width must be > 0.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Product("Name", "Description", false, 100, Guid.NewGuid(), DateTime.Now, "Image", new Dimensions(1, 1, 0))
            );
            Assert.Equal("The product height must be > 0.", ex.Message);
        }
    }
}