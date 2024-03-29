using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PagedBaseResponseDTO<T>
    {

        public int TotalRegister { get; private set; }
        public List<T> Data { get; private set; }

        public PagedBaseResponseDTO(int totalRegister, List<T> data)
        {
            TotalRegister = totalRegister;
            Data = data;
        }
    }
}