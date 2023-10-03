using Domain.Common.Consts;
using FluentValidation;

namespace Application.Commands.Animals.Create
{
    public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
    {
        public CreateAnimalCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(15)
                .MinimumLength(2)
                .WithErrorCode("animal_name_is_invalid")
                .WithMessage(MessageConst.AnimalNameIsInvalid);

            RuleFor(a => a.Age)
                .NotEmpty()
                .WithErrorCode("animal_age_invalid_type")
                .WithMessage(MessageConst.AnimalAgeInvalidType);
        }
    }
}
