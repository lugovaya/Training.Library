namespace Library.Domain.Models
{
    public class User : BaseItem<string>
    {
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        
        public string FullName { get; set; }
    }
}