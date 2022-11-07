using System.ComponentModel.DataAnnotations;

namespace Online_Cloth_Ordering.ViewModel
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        //public string Username { get; set; }

        //public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
