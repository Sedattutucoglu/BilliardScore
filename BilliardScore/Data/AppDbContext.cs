using BilliardScore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilliardScore.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<PlayerProfile> PlayerProfiles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasKey(x => new { x.UserId, x.RoleId });

        modelBuilder.Entity<User>()
            .HasOne(x => x.PlayerProfile)
            .WithOne(x => x.User)
            .HasForeignKey<PlayerProfile>(x => x.UserId);

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "TournamentOwner" },
            new Role { Id = 3, Name = "Player" }
        );

        base.OnModelCreating(modelBuilder);
    }
}