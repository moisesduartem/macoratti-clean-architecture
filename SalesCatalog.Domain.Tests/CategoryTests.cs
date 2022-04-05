using FluentAssertions;
using SalesCatalog.Domain.Entities;
using SalesCatalog.Domain.Validation;
using System;
using Xunit;

namespace SalesCatalog.Domain.Tests
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategory_WithValidParameters_NotThrowDomainValidationException()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainValidationException>(); 
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_ThrowsDomainValidationException()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainValidationException>().WithMessage("Invalid id value");
        }
        
        [Fact]
        public void CreateCategory_ShortName_ThrowsDomainValidationException()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainValidationException>().WithMessage("Too short name, minimum 3 characters");
        }
        
        [Fact]
        public void CreateCategory_EmptyName_ThrowsDomainValidationException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainValidationException>().WithMessage("Name can't be null or empty");
        }
        
        [Fact]
        public void CreateCategory_NullName_ThrowsDomainValidationException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainValidationException>().WithMessage("Name can't be null or empty");
        }
    }
}
