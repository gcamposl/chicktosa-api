using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Plan(int petId, int personId, decimal price)
        {
            Validation(petId, personId, price);
        }

        public Plan(int id, int petId, int personId, decimal price)
        {
            DomainValidationException.When(id < 0, "Id inválido!");
            Id = id;
            Validation(petId, personId, price);
        }
        private void Validation(int petId, int personId, decimal price)
        {
            DomainValidationException.When(PetId < 0, "Id do produto inválido!");
            DomainValidationException.When(personId < 0, "Id da pessoa inválido!");
            DomainValidationException.When(price < 0, "Preço inválido!");

            PersonId = personId;
            PetId = petId;
            Price = price;
            Maturity = DateTime.Now;
        }
    }
}