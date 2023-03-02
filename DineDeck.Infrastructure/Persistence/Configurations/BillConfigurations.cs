using DineDeck.Domain.BillAggregate;
using DineDeck.Domain.BillAggregate.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineDeck.Infrastructure.Persistence.Configurations;

public class BillConfigurations : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        ConfigureBillsTable(builder);
    }

    private void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("BillId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillId.Create(value));

        builder.Property(b => b.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(b => b.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(b => b.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.OwnsOne(b => b.Price);
    }
}
