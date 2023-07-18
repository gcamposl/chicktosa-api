using Application.DTOs.Person;
using FluentValidation;

namespace Application.DTOs.Validations
{
  public class PersonDTOValidator : AbstractValidator<PersonDTO>
  {
    public PersonDTOValidator()
    {
      RuleFor(x => x.Document)
        .NotNull()
        .NotEmpty()
        .WithMessage("Campo document deve ser informado!");

      RuleFor(x => x.Name)
        .NotNull()
        .NotEmpty()
        .WithMessage("Campo name deve ser informado");

      RuleFor(x => x.Phone)
        .NotNull()
        .NotEmpty()
        .WithMessage("Campo phone deve ser informado");
    }
  }
}