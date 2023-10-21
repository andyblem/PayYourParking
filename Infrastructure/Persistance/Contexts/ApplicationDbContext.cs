using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class ApplicationDbContext : AuditableDbContext
    {
        public ApplicationDbContext(IAuthenticatedUserService authenticatedUser, IDateTimeService dateTime, DbContextOptions options) 
            : base(authenticatedUser, dateTime, options)
        {
        }
    }
}
