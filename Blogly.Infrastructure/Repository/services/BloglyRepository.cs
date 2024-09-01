using Blogly.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blogly.Infrastructure.Repository.services;

public class BloglyRepository(BloglyDbContext context) : IBloglyRepository
{
    public async Task<bool> CreateNewUserAsync(ApplicationUser request, CancellationToken token)
    {
        var user = context.ApplicationUsers.Add(request);
        return await context.SaveChangesAsync(token) > 0;
    }

    public async Task<bool> CreateNewBlogAsync(Blog request, CancellationToken token)
    {
        var blog = context.Blogs.Add(request);
        return await context.SaveChangesAsync(token) > 0;
    }

    public async Task<bool> CreateNewCommentAsync(Comment request, CancellationToken token)
    {
        var comment = context.Comments.Add(request);
        return await context.SaveChangesAsync(token) > 0;
    }

    public async Task<IEnumerable<ApplicationUser>> GetUsersAsync(CancellationToken token)
    {
        var users = await context.ApplicationUsers.ToListAsync(token);
        return users;
    }

    public async Task<ApplicationUser?> GetUserAsync(Guid userId, CancellationToken token)
    {
        var user = await context.ApplicationUsers
                                .Include(x => x.Blogs)
                                .FirstOrDefaultAsync(x => x.Id == userId, token);
        return user;
    }

    public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken token)
    {
        var user = await context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Id == userId, token);

        if (user is not null) context.Remove(user);

        return await context.SaveChangesAsync(token) > 0;
    }
}