using Microsoft.EntityFrameworkCore;

namespace Storage;

public sealed class DatabaseContext : DbContext
{
    public DbSet<Boardgame> Boardgames { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ArgumentNullException.ThrowIfNull(modelBuilder);

        modelBuilder.Entity<Boardgame>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Boardgame>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
}
