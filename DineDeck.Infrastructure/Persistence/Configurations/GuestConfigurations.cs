using DineDeck.Domain.DinnerAggregate.ValueObjects;
using DineDeck.Domain.GuestAggregate;
using DineDeck.Domain.GuestAggregate.ValueObjects;
using DineDeck.Domain.HostAggregate.ValueObjects;
using DineDeck.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DineDeck.Infrastructure.Persistence.Configurations;

public class GuestConfigurations : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestsTable(builder);
        ConfigureGuestUpcomingDinnerIdsTable(builder);
        ConfigureGuestPastDinnerIdsTable(builder);
        ConfigureGuestPendingDinnerIdsTable(builder);
        ConfigureGuestBillIdsTable(builder);
        ConfigureGuestMenuReviewIdsTable(builder);
        ConfigureGuestRatingsTable(builder);
    }

    private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasColumnName("GuestId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(g => g.FirstName)
            .HasMaxLength(100);

        builder.Property(g => g.LastName)
            .HasMaxLength(100);

        builder.Property(g => g.ProfileImage)
            .HasMaxLength(100);

        builder.Property(g => g.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }

    private void ConfigureGuestUpcomingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.UpcomingDinnerIds, sb =>
        {
            sb.ToTable("GuestUpcomingDinnerIds");

            sb.WithOwner().HasForeignKey("GuestId");

            sb.HasKey("Id");

            sb.Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Guest.UpcomingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestPastDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PastDinnerIds, sb =>
       {
           sb.ToTable("GuestPastDinnerIds");

           sb.WithOwner().HasForeignKey("GuestId");

           sb.HasKey("Id");

           sb.Property(d => d.Value)
               .HasColumnName("DinnerId")
               .ValueGeneratedNever();
       });

        builder.Metadata.FindNavigation(nameof(Guest.PastDinnerIds))!
             .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestPendingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PendingDinnerIds, sb =>
      {
          sb.ToTable("GuestPendingDinnerIds");

          sb.WithOwner().HasForeignKey("GuestId");

          sb.HasKey("Id");

          sb.Property(d => d.Value)
              .HasColumnName("DinnerId")
              .ValueGeneratedNever();
      });

        builder.Metadata.FindNavigation(nameof(Guest.PendingDinnerIds))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestBillIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.BillIds, sb =>
      {
          sb.ToTable("GuestBillIds");

          sb.WithOwner().HasForeignKey("GuestId");

          sb.HasKey("Id");

          sb.Property(d => d.Value)
              .HasColumnName("BillId")
              .ValueGeneratedNever();
      });

        builder.Metadata.FindNavigation(nameof(Guest.BillIds))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestMenuReviewIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.MenuReviewIds, sb =>
      {
          sb.ToTable("GuestMenuReviewIds");

          sb.WithOwner().HasForeignKey("GuestId");

          sb.HasKey("Id");

          sb.Property(d => d.Value)
              .HasColumnName("MenuReviewId")
              .ValueGeneratedNever();
      });

        builder.Metadata.FindNavigation(nameof(Guest.MenuReviewIds))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.GuestRatings, sb =>
      {
          sb.ToTable("GuestRatings");

          sb.WithOwner().HasForeignKey("GuestId");

          sb.HasKey(nameof(Guest.Id), "GuestId");

          sb.Property(d => d.Id)
              .HasColumnName("GuestRatingsId")
              .ValueGeneratedNever()
              .HasConversion(
                id => id.Value,
                value => RatingId.Create(value));

          sb.Property(d => d.HostId)
              .HasColumnName("HostId")
              .ValueGeneratedNever()
              .HasConversion(
                  id => id.Value,
                  value => HostId.Create(value));

          sb.Property(d => d.DinnerId)
              .HasColumnName("DinnerId")
              .ValueGeneratedNever()
              .HasConversion(
                  id => id.Value,
                  value => DinnerId.Create(value));
      });

        builder.Metadata.FindNavigation(nameof(Guest.GuestRatings))!
              .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}