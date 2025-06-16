using Microsoft.EntityFrameworkCore;

namespace _20MRows;
public class Record
{
    public int Id { get; set; }
    public string ISSN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedAt { get; set; }
    public int Pages { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
}


public class AppDbContext : DbContext
{
    public DbSet<Record> Records => Set<Record>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=144.91.75.57,1433;Database=EfCoreBulkDb;User Id=sa;Password=Pa1884290w0rd#2001;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Record>()
            .HasIndex(r => r.ISSN);
    }
}
