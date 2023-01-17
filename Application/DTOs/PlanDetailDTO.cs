using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PlanDetailDTO
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Pet { get; set; }
        public DateTime Date { get; set; }
    }
}