namespace Blogly.Contracts.Requests;

public class CreateUserRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required int Age { get; set; }
    public required string Country { get; set; }
}