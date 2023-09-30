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
        [MaxLength(20, ErrorMessage = "UserName is too long.")]
		[MinLength(5, ErrorMessage = "UserName is too short.")]
		public string? UserName { get; set; }
		[Required]
		[MaxLength(20, ErrorMessage = "Password is too long.")]
		[MinLength(5, ErrorMessage = "Password is too short.")]
		public string? Password { get; set; }
        public string Role { get; set; }
    }
}
