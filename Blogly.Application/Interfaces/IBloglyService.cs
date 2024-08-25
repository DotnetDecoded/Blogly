using Blogly.Contracts.Requests;
using Blogly.Contracts.Responses;
using Blogly.Domain.Entities;

namespace Blogly.Application.Interfaces;

public interface IBloglyService
{
    Task<CreateUserResponse?> CreateNewUserAsync(CreateUserRequest request, CancellationToken token);
    Task<CreateBlogResponse?> CreateNewBlogAsync(CreateBlogRequest request, CancellationToken token);
    Task<CreateCommentResponse?> CreateNewCommentAsync(CreateCommentRequest request, CancellationToken token);
    Task<GetUsersResponse> GetUsersAsync(CancellationToken token);
    Task<CreateUserResponse?> GetUserAsync(Guid userId, CancellationToken token);
    Task<bool> DeleteUserAsync(Guid userId, CancellationToken token);
}