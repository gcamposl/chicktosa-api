using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Domain.Validations;

namespace Ck.Server.Domain.Entities
{
  public sealed class Person
  {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }
    public ICollection<Plan> Plan { get; set; }

    public Person(string name, string document, string phone)
    {
      Validation(name, document, phone);
    }

    public Person(int id, string name, string document, string phone)
    {
      DomainValidationException.When(id < 0, "Id inválido!");
      Id = id;
      Validation(name, document, phone);
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