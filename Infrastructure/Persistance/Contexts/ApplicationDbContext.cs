using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace Persistance.Contexts
{
    public class ApplicationDbContext : AuditableDbContext
    {
        public DbSet<CityCouncil> CityCouncils { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ParkingTicket> ParkingTickets { get; set; }
        public DbSet<ParkingTicketCost> ParkingTicketCosts { get; set; }
        public DbSet<ParkingTicketPayment> ParkingTicketPayments { get; set; }
        public DbSet<PaymentPlatform> PaymentPlatforms { get; set; }


        public ApplicationDbContext(IAuthenticatedUserService authenticatedUser, IDateTimeService dateTime, DbContextOptions options) 
            : base(authenticatedUser, dateTime, options)
        {
        }
    }
}
