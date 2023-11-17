using FluentValidation;
using MinimalAPI.CouponApi.Models;

namespace MinimalAPI.CouponApi.Validations
{
    public class CreateCouponValidator : AbstractValidator<CreateCouponDto>
    {
        public CreateCouponValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Percent)
                .InclusiveBetween(1, 100);
        }
    }
}
