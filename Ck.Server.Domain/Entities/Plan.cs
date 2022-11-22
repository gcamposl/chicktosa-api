using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ck.Server.Domain.Entities
{
  public class Plan
  {
    public int Id { get; private set; }
    public int PersonId { get; private set; }
    public int PersonId { get; private set; }
    public DateTime Maturity { get; private set; }
    public decimal Value { get; private set; }
  }
}