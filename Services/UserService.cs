namespace YourNamespace.Services
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User { Id = 1, Email = "guldali@test.com", Password = "123456" },
                new User { Id = 2, Email = "user2@example.com", Password = "hash2" }
            };
        }

        public bool RegisterUser(string email, string password)
        {
            if (_users.Any(u => u.Email == email))
            {
                return false; // Email zaten kayıtlı
            }

            var newUser = new User
            {
                Id = _users.Count + 1,
                Email = email,
                Password = password // Hashlenmiş şifre burada olmalı, ancak dummy olarak şifreyi saklıyoruz
            };

            _users.Add(newUser);
            return true; // Kayıt başarılı
        }

        public User GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }
}
