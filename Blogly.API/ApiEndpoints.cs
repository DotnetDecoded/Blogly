namespace Blogly;

public static class ApiEndpoints
{
    private const string Base = "api";
    
    public static class ApplicationUser
    {
        private const string UserBase = $"{Base}/users";
        public const string CreateUser = UserBase;
        public const string GetUsers = $"{Base}/users";
        public const string GetUser = $"{UserBase}/{{id:string}}";
        public const string DeleteUser = $"{UserBase}/{{id:string}}";

    }
}