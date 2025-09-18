using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace holy.web.Services
{
    public class InMemoryUserStore : IUserStore
    {
        private readonly ConcurrentDictionary<string, User> _users = new();

        public InMemoryUserStore()
        {
            // Add default admin user
            CreateUserAsync("admin", "admin@breakscreen.com", "admin").Wait();
        }

        public Task<bool> CreateUserAsync(string username, string email, string password)
        {
            if (_users.ContainsKey(username.ToLower()))
            {
                return Task.FromResult(false);
            }

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                CreatedAt = DateTime.UtcNow
            };

            return Task.FromResult(_users.TryAdd(username.ToLower(), user));
        }

        public Task<bool> ValidateUserAsync(string username, string password)
        {
            if (_users.TryGetValue(username.ToLower(), out var user))
            {
                return Task.FromResult(VerifyPassword(password, user.PasswordHash));
            }
            return Task.FromResult(false);
        }

        public Task<User?> GetUserAsync(string username)
        {
            _users.TryGetValue(username.ToLower(), out var user);
            return Task.FromResult(user);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + "salt"));
            return Convert.ToBase64String(hashedBytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}