using FluentValidation;

namespace Catalog.Api.Products.Create;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product name is required.");

        RuleFor(x => x.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("Product description is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than zero.");

        RuleFor(x => x.ImagePath)
            .NotNull()
            .NotEmpty()
            .WithMessage("Image path is required.");

        RuleFor(x => x.Categories)
            .NotNull()
            .NotEmpty()
            .WithMessage("At least one category is required.");

        RuleForEach(x => x.Categories)
            .NotNull()
            .NotEmpty()
            .WithMessage("Category cannot be empty.");
    }
}