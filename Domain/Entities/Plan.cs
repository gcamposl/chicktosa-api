using Domain.Validations;

namespace Domain.Entities
{
    public class Plan
    {
        public int Id { get; private set; }
        public int PersonId { get; private set; }
        public int PetId { get; private set; }
        public DateTime Maturity { get; private set; }
        public decimal Price { get; private set; }
        public Pet Pet { get; set; }
        public Person Person { get; set; }

        public Plan(int petId, int personId)
        {
            Validation(petId, personId);
        }
        public Plan(int id, int petId, int personId)
        {
            DomainValidationException.When(id <= 0, "Id inválido!");
            Id = id;
            Validation(petId, personId);
        }
        private void Validation(int petId, int personId)
        {
            DomainValidationException.When(petId <= 0, "Id do pet inválido!");
            DomainValidationException.When(personId <= 0, "Id da pessoa inválido!");

            PersonId = personId;
            PetId = petId;
            Price = 0;
            Maturity = DateTime.Now;
        }
    }
}