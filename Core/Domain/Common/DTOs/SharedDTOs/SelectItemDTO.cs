using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DTOs.SharedDTOs
{
    public class SelectItemDTO<T>
    {
        public string? Label { get; set; }
        public T? Value { get; set; }
    }
}
