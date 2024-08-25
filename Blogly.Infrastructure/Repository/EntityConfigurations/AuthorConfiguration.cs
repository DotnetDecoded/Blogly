using Blogly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogly.Infrastructure.Repository.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever();
        builder.HasMany(x => x.Blogs)
            .WithOne(x => x.Author)
            .OnDelete(DeleteBehavior.Cascade);
    }
}