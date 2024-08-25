using Blogly.Sharedkernel;

namespace Blogly.Domain.Entities;

public class Comment() : BaseEntity<Guid>(Guid.NewGuid())
{
    public required string Content { get; set; }
    public required Guid BlogId { get; set; }
    public Blog? Blog { get; set; }
    public required Guid UserId { get; set; }
    public ApplicationUser? User { get; set; }
}