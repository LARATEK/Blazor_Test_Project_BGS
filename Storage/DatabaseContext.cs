using Microsoft.EntityFrameworkCore;

namespace Storage;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Boardgames> Boardgames { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.Entity<Boardgames>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Boardgames>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}
