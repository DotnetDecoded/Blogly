namespace Blogly.Contracts.Responses;

public class CreateBlogResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public required Guid AuthorId { get; set; }
    public required IEnumerable<CreateCommentResponse> Comments { get; set; } = [];
}