
namespace Domain.Entities
{
    public class UserClient
    {
        public int IdUserClient { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password2 { get; private set; } = string.Empty;

        protected UserClient() { }

        public UserClient(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password2 = EncodePassword(password);
        }

        public string EncodePassword(string password)
        {
           return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public string DecodePassword(string encodedPassword)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(encodedPassword));
        }
    }
}
