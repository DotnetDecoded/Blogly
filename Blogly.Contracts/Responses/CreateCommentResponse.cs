namespace Blogly.Contracts.Responses;

public class CreateCommentResponse
{
    public Guid Id { get; set; }
    public required string Content { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid UserId { get; set; }
}