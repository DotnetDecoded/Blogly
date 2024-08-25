using Blogly.Sharedkernel;

namespace Blogly.Domain.Entities;

public class Blog() : BaseEntity<Guid>(Guid.NewGuid())
{
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required Guid AuthorId { get; set; }
    public ApplicationUser? Author { get; set; }
    public IEnumerable<Comment> Comments { get; set; } = [];
}