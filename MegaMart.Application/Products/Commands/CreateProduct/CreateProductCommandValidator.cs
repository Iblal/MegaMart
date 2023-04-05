using FluentValidation;

namespace MegaMart.Application.Products.Commands.CreateProduct
{
    internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);

            RuleFor(x => x.Price).NotEmpty().LessThan(500);

            RuleFor(x => x.Category).IsInEnum();

            RuleFor(x => x.Quantity).NotEmpty().LessThan(1000);
        }
    }
}
