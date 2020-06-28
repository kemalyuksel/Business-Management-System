using FluentValidation;
using Management.Dto.DTOs.ReportDTOs;

namespace Management.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("Bu alan boş geçilemez");
            RuleFor(x => x.Detail).NotNull().WithMessage("Bu alan boş geçilemez");
        }
    }
}
