using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Integrations
{
    public interface ISavePersonImage
    {
        string Save(string base64);
    }
}