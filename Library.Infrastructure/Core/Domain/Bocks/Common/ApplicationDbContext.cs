using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Bocks.Models;
using Microsoft.EntityFrameworkCore;
using Library.Persistence.EntityConfigurations;

public class ApplicationDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Bock> Bocks { get; set; }
    public DbSet<BockAuthor> BocksAuthors { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new BockEntityTypeConfiguration());
        
    }
}
