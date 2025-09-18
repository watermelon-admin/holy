namespace holy.web.Services
{
    public interface IUserStore
    {
        Task<bool> CreateUserAsync(string username, string email, string password);
        Task<bool> ValidateUserAsync(string username, string password);
        Task<User?> GetUserAsync(string username);
    }

    public class User
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}