namespace EFCore.Relationships.Models
{
    public class User // Acount(UserId) (1:1) User({Account*})
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Account Account { get; set; }
    }
}
