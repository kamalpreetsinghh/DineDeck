using DineDeck.Domain.Common.ValueObjects;
using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.MenuAggregate.ValueObjects;
using DineDeck.Domain.MenuReviewAggregate;
using DineDeck.Domain.MenuReviewAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineDeck.Infrastructure.Persistence.Configurations;

public class MenuReviewConfigurations : IEntityTypeConfiguration<MenuReview>
{
    public void Configure(EntityTypeBuilder<MenuReview> builder)
    {
        ConfigureMenuReviewsTable(builder);
    }

    private void ConfigureMenuReviewsTable(EntityTypeBuilder<MenuReview> builder)
    {
        builder.ToTable("MenuReviews");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .HasColumnName("MenuReviewId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuReviewId.Create(value));

        builder.Property(m => m.Comment)
            .HasMaxLength(100);

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(m => m.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(m => m.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(m => m.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));
    }
}
