using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.HostAggregate;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineDeck.Infrastructure.Persistence.Configurations;

public class HostConfigurations : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureHostDinnerIdsTable(builder);
        ConfigureHostMenuIdsTable(builder);
    }

    private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .HasColumnName("HostId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(h => h.FirstName)
            .HasMaxLength(100);

        builder.Property(h => h.LastName)
            .HasMaxLength(100);

        builder.Property(h => h.ProfileImage)
            .HasMaxLength(100);

        builder.OwnsOne(h => h.AverageRating);

        builder.Property(h => h.UserId)
            .HasColumnName("UserId")
            .HasConversion(
                rating => rating.Value,
                value => UserId.Create(value));
    }

    private void ConfigureHostDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, db =>
         {
             db.ToTable("HostDinnerIds");

             db.WithOwner().HasForeignKey("HostId");

             db.HasKey("Id");

             db.Property(d => d.Value)
                 .HasColumnName("DinnerId")
                 .ValueGeneratedNever();
         });

        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
           .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.MenuIds, mb =>
       {
           mb.ToTable("HostMenuIds");

           mb.WithOwner().HasForeignKey("HostId");

           mb.HasKey("Id");

           mb.Property(m => m.Value)
               .HasColumnName("MenuId")
               .ValueGeneratedNever();
       });

        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
           .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}