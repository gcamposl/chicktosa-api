using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ck.Server.Domain.Validations;

namespace Ck.Server.Domain.Entities
{
  public class Plan
  {
    public int Id { get; private set; }
    public int PersonId { get; private set; }
    public int PersonId { get; private set; }
    public DateTime Maturity { get; private set; }
    public decimal Price { get; private set; }
    public Pet Pet { get; set; }
    public Person Person { get; set; }

    public Plan(int productId, int personId, DateTime? maturity, decimal price)
    {
      Validation(productId, personId, maturity, price);
    }

    public Plan(int id, int productId, int personId, DateTime? maturity, decimal price)
    {
      DomainValidationException(id < 0, "Id inválido!");
      Id = id;
      Validation(productId, personId, maturity, price);
    }
    private void Validation(int productId, int personId, DateTime? maturity, decimal price)
    {
      DomainValidationException.When(productId < 0, "Id do produto inválido!");
      DomainValidationException.When(personId < 0, "Id da pessoa inválido!");
      DomainValidationException.When(!maturity.HasValue, "Data de vencimento inválida!");
      DomainValidationException.When(price < 0, "Preço inválido!");

      PersonId = personId;
      ProductId = productId;
      Maturity = maturity.Value;
      Price = price;
    }
  }
}