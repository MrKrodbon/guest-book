using GuestBookService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuestBookService.Data;
public class GuestBookDbContext : DbContext
{
    public GuestBookDbContext(DbContextOptions<GuestBookDbContext> options) : base(options)
    {

    }

    public DbSet<GuestBookEntity> GuestBookEntity { get; set; }

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
