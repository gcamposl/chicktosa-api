using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PlanDTO
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public int Id { get; set; }
        public string? PetName { get; set; }
        public decimal? Price { get; set; }
    }
}