using System.ComponentModel.DataAnnotations;

namespace Product_CRUD.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Please Enter your email")]
        public string Email { get; set; }
        
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter your strong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
