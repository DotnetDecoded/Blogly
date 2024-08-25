using Blogly.Sharedkernel;

namespace Blogly.Domain.Entities;

public class ApplicationUser() : BaseEntity<Guid>(Guid.NewGuid())
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Role Role { get; set; }
    public required int Age { get; init; }
    public required string Country { get; set; }
    public IEnumerable<Blog> Blogs { get; set; } = [];
}