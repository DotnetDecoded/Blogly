using Blogly.Domain.Entities;
using Blogly.Infrastructure.Repository.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Blogly.Infrastructure.Repository;

public class BloglyDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    public BloglyDbContext(DbContextOptions<BloglyDbContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}