using DineDeck.Domain.BillAggregate.ValueObjects;
using DineDeck.Domain.DinnerAggregate;
using DineDeck.Domain.DinnerAggregate.Entities;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineDeck.Infrastructure.Persistence.Configurations;

public class DinnerConfigurations : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureDinnerReservationsTable(builder);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(1000);

        builder.OwnsOne(d => d.Price);

        builder.OwnsOne(d => d.Location);

        builder.Property(d => d.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(d => d.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));
    }

    private void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(d => d.Reservations, rb =>
        {
            rb.ToTable("DinnerReservations");

            rb.WithOwner().HasForeignKey("DinnerId");

            rb.HasKey(nameof(Reservation.Id), "DinnerId");

            rb.Property(r => r.Id)
                .HasColumnName("DinnerReservationId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => ReservationId.Create(value));

            rb.Property(r => r.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

            rb.Property(r => r.BillId)
                .HasConversion(
                    id => id.Value,
                    value => BillId.Create(value));
        });

        builder.Metadata.FindNavigation(nameof(Dinner.Reservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
