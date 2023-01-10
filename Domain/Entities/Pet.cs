using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Pet
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Race { get; private set; }
        public decimal Weight { get; private set; }
        public ICollection<Plan> Plan { get; set; }

        public Pet(string name, string race, decimal weight)
        {
            Validation(name, race, weight);
        }

        public Pet(int id, string name, string race, decimal weight)
        {
            DomainValidationException.When(id < 0, "Id inválido!");
            Id = id;
            Validation(name, race, weight);
        }
        private void Validation(string name, string race, decimal weight)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Nome inválido!");
            DomainValidationException.When(string.IsNullOrEmpty(race), "Raça inválido!");
            DomainValidationException.When(weight < 0, "Peso inválido!");

            Name = name;
            Race = race;
            Weight = weight;
        }
    }
}