using GuestBookService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBookService;
public class GuestBookContext : DbContext
{
    public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<GuestBookEntity> GuestBookEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GuestBookEntity>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<GuestBookEntity>()
            .Property(b => b.GuestName)
            .HasMaxLength(128)
            .IsRequired();

        modelBuilder.Entity<GuestBookEntity>()
            .Property(b => b.Comment)
            .HasMaxLength(140)
            .IsRequired();
    }
}
