using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                 .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Category Name")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                 .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid id. Id must be greater than zero.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                 .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                 .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                 .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Name is required");
        }
    }
}