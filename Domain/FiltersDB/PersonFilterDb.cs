using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Domain.FiltersDB
{
    public class PersonFilterDb : PagedBaseRequest
    {
        public string Name { get; set; }
    }
}