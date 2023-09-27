namespace BTMAppUI.Data.Models
{
    public class User
    {
        public User()
        {
            Role = "User";
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
