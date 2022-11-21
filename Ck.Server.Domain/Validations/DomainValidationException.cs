using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ck.Server.Domain.Validations
{
  public class DomainValidationException : Exception
  {

    public DomainValidationException(string error) : base(error)
    { }

    public static void When(string hasError, string message)
    {
      if (hasError)
      {
        throw new DomainValidationException(message);
      }
    }
  }
}