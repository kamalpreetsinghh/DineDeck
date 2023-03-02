using DineDeck.Domain.BillAggregate;
using DineDeck.Domain.DinnerAggregate;
using DineDeck.Domain.GuestAggregate;
using DineDeck.Domain.HostAggregate;
using DineDeck.Domain.MenuAggregate;
using DineDeck.Domain.MenuReviewAggregate;
using DineDeck.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace DineDeck.Infrastructure.Persistence;

public class DineDeckDbContext : DbContext
{
    public DineDeckDbContext(DbContextOptions<DineDeckDbContext> options) : base(options) { }

    // public DbSet<Menu> Menus { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Host> Hosts { get; set; } = null!;

    public DbSet<Guest> Guests { get; set; } = null!;

    public DbSet<Dinner> Dinners { get; set; } = null!;

    public DbSet<Bill> Bills { get; set; } = null!;

    public DbSet<MenuReview> MenuReviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DineDeckDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}