using FluentValidation;
using Management.Dto.DTOs.WorkDTOs;

namespace Management.Business.ValidationRules.FluentValidation
{
    public class WorkAddValidator : AbstractValidator<WorkAddDto>
    {
        public WorkAddValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir aciliyet seçiniz");
        }
    }
}
