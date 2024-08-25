namespace Blogly.Contracts.Requests;

public class CreateCommentRequest
{
    public required string Content { get; set; }
    public required Guid BlogId { get; set; }
    public required Guid UserId { get; set; }
}