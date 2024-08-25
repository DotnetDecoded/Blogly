using Blogly.Contracts.Requests;
using Blogly.Contracts.Responses;
using Blogly.Domain.Entities;

namespace Blogly.Contracts.Mappings;

public static class ModelMappings
{
    public static ApplicationUser MapToUserEntity (this CreateUserRequest request)
    {
        return new ApplicationUser()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Age = request.Age,
            Country = request.Country
        };
    }
    
    public static CreateUserResponse MapToResponse (this ApplicationUser entity)
    {
        return new CreateUserResponse()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Age = entity.Age,
            Role = entity.Role.ToString(),
            Country = entity.Country,
            Blogs = entity.Blogs.Select(MapToBlogResponse)
        };
    }
    
    public static Blog MapToBlogEntity (this CreateBlogRequest request)
    {
        return new Blog()
        {
            Title = request.Title,
            Content = request.Content,
            AuthorId = request.AuthorId,
        };
    }
    
    public static CreateBlogResponse MapToBlogResponse (this Blog entity)
    {
        return new CreateBlogResponse()
        {
            Id = entity.Id,
            Title = entity.Title,
            Content = entity.Content,
            Comments = entity.Comments.Select(MapToCommentResponse),
            AuthorId = entity.AuthorId,
        };
    }
    
    public static Comment MapToEntity (this CreateCommentRequest request)
    {
        return new Comment()
        {
            Content = request.Content,
            BlogId = request.BlogId,
            UserId = request.UserId,
        };
    }
    
    public static CreateCommentResponse MapToCommentResponse (this Comment entity)
    {
        return new CreateCommentResponse()
        {
            Id = entity.Id,
            Content = entity.Content,
            BlogId = entity.BlogId,
            UserId = entity.UserId,
        };
    }

    public static GetUsersResponse MapToResponse(this IEnumerable<ApplicationUser> entity)
    {
        return new GetUsersResponse()
        {
            Users = entity.Select(MapToResponse)
        };
    }
}