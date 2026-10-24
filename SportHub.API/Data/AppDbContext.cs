using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<SportType> SportTypes => Set<SportType>();
        public DbSet<Venue> Venues => Set<Venue>();
        public DbSet<Court> Courts => Set<Court>();
        public DbSet<PriceRule> PriceRules => Set<PriceRule>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<BookingSlot> BookingSlots => Set<BookingSlot>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Notification> Notifications => Set<Notification>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
