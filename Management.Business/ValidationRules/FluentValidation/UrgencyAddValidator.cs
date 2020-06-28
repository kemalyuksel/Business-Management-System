using FluentValidation;
using Management.Dto.DTOs.UrgencyDTOs;

namespace Management.Business.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {

        public UrgencyAddValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("Bu alan boş geçilemez.");
        }

    }
}
