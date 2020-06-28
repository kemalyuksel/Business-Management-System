using FluentValidation;
using Management.Dto.DTOs.AppUserDTOs;

namespace Management.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Bu alan boş geçilemez");

        }

    }
}
