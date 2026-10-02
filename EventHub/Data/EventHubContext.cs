using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EventHub.Data
{
    public class EventHubContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<Registration> Registrations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=EventHub;Trusted_Connection=True;TrustServerCertificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(builder =>
            {
                builder.HasKey(x => x.Id);

                builder.HasOne(x => x.ParentEvent)
                       .WithMany(x => x.Sessions)
                       .HasForeignKey(x => x.ParentEventId);

                builder.Property<DateTime>("CreatedAt")
                       .HasDefaultValueSql("GETDATE()")
                       .ValueGeneratedOnAdd();

                builder.Property<DateTime>("ModifiedAt");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<Event>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("ModifiedAt").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("ModifiedAt").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}