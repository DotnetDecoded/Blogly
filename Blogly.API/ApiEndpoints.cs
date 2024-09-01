namespace Blogly;

public static class ApiEndpoints
{
    private const string Base = "api";

    public static class ApplicationUser
    {
        private const string UserBase = $"{Base}/users";
        public const string CreateUser = UserBase;
        public const string GetUsers = $"{Base}/users";
        public const string GetUser = $"{UserBase}/{{id:Guid}}";
        public const string DeleteUser = $"{UserBase}/{{id:Guid}}";
    }

    public static class Blog
    {
        private const string BlogBase = $"{Base}/Blogs";
        public const string CreateBlog = BlogBase;
        public const string GetBlogs = $"{Base}/Blogs";
        public const string GetBlog = $"{BlogBase}/{{id:Guid}}";
        public const string DeleteBlog = $"{BlogBase}/{{id:Guid}}";
    }
}