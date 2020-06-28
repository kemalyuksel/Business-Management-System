using FluentValidation;
using Management.Dto.DTOs.UrgencyDTOs;

namespace Management.Business.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator : AbstractValidator<UrgencyUpdateDto>
    {

        public UrgencyUpdateValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("Bu alan boş geçilemez");
        }
    }
}
