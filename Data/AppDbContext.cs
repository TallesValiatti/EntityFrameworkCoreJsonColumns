using EntityFrameworkCoreJsonColumns.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreJsonColumns.Data;

class AppDbContext : DbContext
{
     public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server=localhost,1435;Database=App;User Id=sa;Password=Teste12345!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().OwnsOne(
            book => book.Details, ownedNavigationBuilder =>
            {
                ownedNavigationBuilder.ToJson();
                ownedNavigationBuilder.OwnsMany(x => x.Tags);
            });
    }
}