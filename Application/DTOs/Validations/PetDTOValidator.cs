using Application.DTOs.Pet;
using FluentValidation;

namespace Application.DTOs.Validations
{
    public class PetDTOValidator : AbstractValidator<PetDTO>
    {
        public PetDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome do Pet deve ser informado!");
            RuleFor(x => x.Race)
                .NotEmpty()
                .NotNull()
                .WithMessage("Raça do Pet deve ser informado!");
            RuleFor(x => x.Weight)
                .GreaterThan(0)
                .WithMessage("Peso do Pet deve ser maior do que 0!");
        }
    }
}