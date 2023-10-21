using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BEntity : IAuditable
    {
        public bool? IsDeleted { get; set; }
        public bool? IsModified { get; set; }
        public bool? IsRestored { get; set; }

        public int Id { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? RestoredAt { get; set; }


        public string? CreatedById { get; set; }
        public string? DeletedById { get; set; }
        public string? ModifiedById { get; set; }
        public string? RestoredById { get; set; }
    }
}
