using FluentAssertions;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Validation;
using System;
using Xunit;

namespace SalesCatalog.Domain.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CreateCategory_WithValidParameters_NotThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().NotThrow<DomainValidationException>();
        }

        [Fact]
        public void CreateCategory_WithNegativeId_ThrowDomainValidationException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid id value");
        }

        [Fact]
        public void CreateCategory_WithEmptyName_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Name can't be null or empty");
        }

        [Fact]
        public void CreateCategory_WithNullName_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Name can't be null or empty");
        }

        [Fact]
        public void CreateCategory_WithShortName_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Too short name, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_WithEmptyDescription_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Description can't be null or empty");
        }

        [Fact]
        public void CreateCategory_WithNullDescription_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Description can't be null or empty");
        }

        [Fact]
        public void CreateCategory_WithShortDescription_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", "Prod", 9.99m, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Too short description, minimum 5 characters");
        }

        [Fact]
        public void CreateCategory_WithNegativePrice_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1, 99, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid price value");
        }

        [Fact]
        public void CreateCategory_WithNegativeStock_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "product image");
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid stock value");
        }

        [Fact]
        public void CreateCategory_WithLongImageName_ThrowDomainValidationException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium q");
            action.Should().Throw<DomainValidationException>().WithMessage("Too long image name, maximum 250 characters");
        }
    }
}
