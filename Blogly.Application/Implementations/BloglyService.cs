using Blogly.Application.Interfaces;
using Blogly.Contracts.Mappings;
using Blogly.Contracts.Requests;
using Blogly.Contracts.Responses;
using Blogly.Infrastructure.Repository.services;

namespace Blogly.Application.Implementations;

public class BloglyService(IBloglyRepository bloglyRepository) : IBloglyService
{
    public async Task<CreateUserResponse?> CreateNewUserAsync(CreateUserRequest request, CancellationToken token)
    {
        var user = request.MapToUserEntity();
        var isUserCreated = await bloglyRepository.CreateNewUserAsync(user, token);

        return isUserCreated ? user.MapToResponse() : null;
    }

    public async Task<CreateBlogResponse?> CreateNewBlogAsync(CreateBlogRequest request, CancellationToken token)
    {
        var blog = request.MapToBlogEntity();
        var isBlogCreated = await bloglyRepository.CreateNewBlogAsync(blog, token);

        return isBlogCreated ? blog.MapToBlogResponse() : null;
    }

    public async Task<CreateCommentResponse?> CreateNewCommentAsync(CreateCommentRequest request, CancellationToken token)
    {
        var comment = request.MapToEntity();
        var isCommentCreated = await bloglyRepository.CreateNewCommentAsync(comment, token);

        return isCommentCreated ? comment.MapToCommentResponse() : null;
    }

    public async Task<GetUsersResponse> GetUsersAsync(CancellationToken token)
    {
        var users = await bloglyRepository.GetUsersAsync(token);

        return users.MapToResponse();
    }

    public async Task<CreateUserResponse?> GetUserAsync(Guid userId, CancellationToken token)
    {
        var user = await bloglyRepository.GetUserAsync(userId, token);

        return user?.MapToResponse();
    }

    public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken token)
    {
        return await bloglyRepository.DeleteUserAsync(userId, token);
    }
}