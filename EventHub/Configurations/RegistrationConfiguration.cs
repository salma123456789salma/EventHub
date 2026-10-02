using EventHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventHub.Configurations
{
    public class RegistrationConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Attendee)
                   .WithMany(x => x.Registrations);

            builder.HasOne(x => x.Event)
                   .WithMany(x => x.Registrations);

            builder.Property(x => x.RegistrationDate)
                   .HasDefaultValueSql("GETDATE()")
                   .ValueGeneratedOnAdd();
        }
    }
}