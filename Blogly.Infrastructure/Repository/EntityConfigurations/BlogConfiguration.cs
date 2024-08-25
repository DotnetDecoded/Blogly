using Blogly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogly.Infrastructure.Repository.EntityConfigurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasMany(x => x.Comments).WithOne(x => x.Blog).OnDelete(DeleteBehavior.Cascade);
    }
}