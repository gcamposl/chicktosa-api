using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ck.Server.Infra.Data.Context
{
  public class ApplicationDbContext : DbContext // AQUI NAO ESTA REFERENCIANDO
  {
    public ApplicationDbContext()
    {

    }
  }
}