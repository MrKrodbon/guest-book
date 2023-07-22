using GuestBook.Service.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Service.Data;
public class GuestBookContext : DbContext
{
    public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
    {
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
