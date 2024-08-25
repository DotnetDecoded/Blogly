using Blogly.Domain.Entities;
using Blogly.Infrastructure.Repository.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Blogly.Infrastructure.Repository;

public class BloglyDbContext(DbContextOptions<BloglyDbContext> options) : DbContext(options)
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}