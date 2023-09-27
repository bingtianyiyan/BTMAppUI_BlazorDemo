using System.ComponentModel.DataAnnotations;

namespace BTMAppUI.Data.Models
{
    public class UserModel
    {
        public UserModel()
        {
            Role = "User";
        }
        [Required]
        [StringLength(100, ErrorMessage = "UserName is too long.")]
        public string? UserName { get; set; }
		[Required]
		[StringLength(100, ErrorMessage = "Password is too long.")]
		[MinLength(5, ErrorMessage = "Password is too short.")]
		public string? Password { get; set; }
        public string Role { get; set; }
    }
}
