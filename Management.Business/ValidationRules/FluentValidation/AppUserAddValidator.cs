using FluentValidation;
using Management.Dto.DTOs.AppUserDTOs;

namespace Management.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserRegisterDto>
    {

        public AppUserAddValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Password).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Email).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Name).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Surname).NotNull().WithMessage("Bu alan boş geçilemez");
        }

    }
}
