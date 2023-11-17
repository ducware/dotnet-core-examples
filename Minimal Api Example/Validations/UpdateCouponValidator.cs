using FluentValidation;
using MinimalAPI.CouponApi.Models;

namespace MinimalAPI.CouponApi.Validations
{
    public class UpdateCouponValidator : AbstractValidator<UpdateCouponDto>
    {
        public UpdateCouponValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Percent)
                .InclusiveBetween(1, 100);
        }
    }
}
