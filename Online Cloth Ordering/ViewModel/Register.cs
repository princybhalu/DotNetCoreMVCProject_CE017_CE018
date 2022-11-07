using System.ComponentModel.DataAnnotations;

namespace Online_Cloth_Ordering.ViewModel
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password) , ErrorMessage = "Password and Confirm Password did not match" )]
        public string ConfirmPassword { get; set; }


    }
}
