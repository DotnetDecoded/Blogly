using System.Security.AccessControl;

namespace Blogly.Contracts.Responses;

public class GetUsersResponse
{
    public IEnumerable<CreateUserResponse> Users
    {
        get;
        set;
    }
}