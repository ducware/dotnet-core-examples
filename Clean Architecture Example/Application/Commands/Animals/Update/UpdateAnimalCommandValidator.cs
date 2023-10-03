using Domain.Common.Consts;
using FluentValidation;

namespace Application.Commands.Animals.Update
{
    public class UpdateAnimalCommandValidator : AbstractValidator<UpdateAnimalCommand>
    {
        public UpdateAnimalCommandValidator()
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

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithErrorCode("animal_description_is_required")
                .WithMessage(MessageConst.AnimalDescrptionIsRequired);

            RuleFor(a => a.IsBird)
                .NotEmpty()
                .WithErrorCode("is_bird_field_is_required")
                .WithMessage(MessageConst.IsBirdFieldIsRequired);
        }
    }
}
