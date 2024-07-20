using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts;

public class LibraryContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }

    public LibraryContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}