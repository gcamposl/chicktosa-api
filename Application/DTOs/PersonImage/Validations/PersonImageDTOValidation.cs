using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;

namespace Application.DTOs.PersonImage.Validations
{
    public class PersonImageDTOValidation : AbstractValidator<PersonImageDTO>
    {
        public PersonImageDTOValidation()
        {
            RuleFor(x => x.PersonId)
            .GreaterThanOrEqualTo(0)
            .WithMessage("PersonId não pode ser menor ou igual a zero!");

            RuleFor(x => x.Image)
            .NotEmpty()
            .NotNull()
            .WithMessage("Image deve ser informado");

        }
    }
}