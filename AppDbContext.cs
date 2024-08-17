using bArtTask.Entities;
using Microsoft.EntityFrameworkCore;

namespace bArtTask;

public class AppDbContext : DbContext
{
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasIndex(a => a.Name)
            .IsUnique();
        
        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();
        
        modelBuilder.Entity<Account>()
            .HasMany(a => a.Contacts)
            .WithOne(c => c.Account)
            .HasForeignKey(c => c.AccountId);
        
        modelBuilder.Entity<Account>()
            .HasMany(a => a.Incidents)
            .WithOne(i => i.Account)
            .HasForeignKey(i => i.AccountId);
    }
}