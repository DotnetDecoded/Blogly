using Blogly.Domain.Entities;
using Blogly.Sharedkernel;

namespace Blogly.Contracts.Responses;

public class CreateUserResponse
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string Role { get; set; }
    public required int Age { get; init; }
    public required string Country { get; set; }
    public IEnumerable<CreateBlogResponse> Blogs { get; set; } = [];
}