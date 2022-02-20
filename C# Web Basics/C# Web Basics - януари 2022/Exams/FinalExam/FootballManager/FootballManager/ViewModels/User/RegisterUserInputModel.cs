using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.User
{
    public class RegisterUserInputModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        [Required]
        public string Username { get; set; }

        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} characters")]
        [Required]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        [Required]
        public string Password { get; set; }


        [Compare(nameof(Password), ErrorMessage = "Password and Confirm Password must be equal")]
        public string ConfirmPassword { get; set; }
    }
}

//•	Has an Id – a string, Primary Key
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email – a string with min length 10 and max length 60 (required)
//•	Has a Password – a string with min length 5 and max length 20 (before hashed)  -no max length required for a hashed password in the database (required)
//•	Has UserPlayers collection
