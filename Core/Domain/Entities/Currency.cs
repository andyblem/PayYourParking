using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Currency : BNamedEntity
    {
        public string? Abbreviation { get; set; }
    }
}
