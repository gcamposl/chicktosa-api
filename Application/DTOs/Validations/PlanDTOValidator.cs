using Application.DTOs.Plan;
using FluentValidation;

namespace Application.DTOs.Validations
{
    public class PlanDTOValidator : AbstractValidator<PlanDTO>
    {
        public PlanDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome do Pet deve ser inserido!");
            RuleFor(X => X.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado!");
        }
    }
}