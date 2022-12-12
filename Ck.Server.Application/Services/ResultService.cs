using System;

namespace Ck.Server.Application.Services
{
  public class ResultService
  {
    public bool IsSucess { get; set; }
    public string Message { get; set; }
    public ICollection<ErrorValidation> Errors { get; set; }
  }

  public class ResultService<T> : ResultService
  {
    public T Data { get; set; }
  }
}