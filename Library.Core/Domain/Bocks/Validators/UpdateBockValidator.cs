using FluentValidation;
using Library.Core.Domain.Bocks.Data;

namespace Library.Core.Domain.Bocks.Validators;

public class UpdateBockValidator : AbstractValidator<UpdateBockData>
{
    public UpdateBockValidator()
    {
        RuleFor(bock => bock.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

        RuleFor(bock => bock.AuthorId)
            .NotEmpty().WithMessage("Author ID is required.");

        RuleFor(bock => bock.Genre)
            .NotEmpty().WithMessage("Genre is required.")
            .Length(1, 50).WithMessage("Genre must be between 1 and 50 characters.");

        RuleFor(bock => bock.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(1, 3000).WithMessage("Description must be between 1 and 3000 characters.");
    }
}
