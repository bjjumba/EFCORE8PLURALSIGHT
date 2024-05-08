using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublishData;

public class PublisherContext:DbContext
{
    private readonly string _connectionString = "Server=localhost;Database=publisher;User=benji;Password=Benji27586*";
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
    }
}