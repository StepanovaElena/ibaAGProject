using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        
        public int[] Permissions { get; set; }
        
        public int[] Membership { get; set; }
    }    
}
