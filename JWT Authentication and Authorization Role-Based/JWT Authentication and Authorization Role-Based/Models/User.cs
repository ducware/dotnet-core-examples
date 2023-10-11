namespace JWT_Authentication_and_Authorization_Role_Based.Models
{
    public class User
    {
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
    }
}
