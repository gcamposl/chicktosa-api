using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using Domain.Validations;

namespace Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public ICollection<Plan> Plan { get; private set; }
        public ICollection<PersonImage> PersonImages { get; private set; }

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
            Plan = new List<Plan>();
            PersonImages = new List<PersonImage>();
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.When(id < 0, "Id inválido!");
            Id = id;
            Validation(name, document, phone);
            PersonImages = new List<PersonImage>();
        }
        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "Informe o nome!");
            DomainValidationException.When(string.IsNullOrEmpty(document), "Informe o documento!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "Informe o telefone!");

            Name = name;
            Document = document;
            Phone = phone;
        }
    }
}