using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalTask.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "First Name is Required.")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "First Name must be between 3 and 12 Charcter.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 12 Charcter.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        //[Range(6, 30, ErrorMessage = "Password must be greater than 5.")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Compare("Password")]
        [DisplayName("Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
