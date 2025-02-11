using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eVillaBooking.Presentation.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string Email {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required,DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword {  get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        public string? RedirectURL { get; set; }


    }
}
