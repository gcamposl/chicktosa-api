using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
    }
}