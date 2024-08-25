using Blogly.Domain.Entities;

namespace Blogly.Infrastructure.Repository.services;

public interface IBloglyRepository
{
    Task<bool> CreateNewUserAsync(ApplicationUser request, CancellationToken token);
    Task<bool> CreateNewBlogAsync(Blog request, CancellationToken token);
    Task<bool> CreateNewCommentAsync(Comment request, CancellationToken token);
    Task<IEnumerable<ApplicationUser>> GetUsersAsync(CancellationToken token);
}