using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels.Player
{
    public class AddPlayerInputModel
    {
        [Required]
        [StringLength(80,MinimumLength =5,ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Position { get; set; }

        [Required]
        [Range(0,10, ErrorMessage = "{0} must be between {1} and {2} characters")]
        public int Speed { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "{0} must be between {1} and {2} characters")]
        public int Endurance { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "{0} must be between no more than {1} characters")]
        public string Description { get; set; }
    }
}

//•	Has Speed – a byte (required); cannot be negative or bigger than 10
//•	Has Endurance – a byte (required); cannot be negative or bigger than 10
//•	Has a Description – a string with max length 200 (required)

