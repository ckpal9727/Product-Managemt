using System.ComponentModel.DataAnnotations;

namespace Product_CRUD.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage ="Please Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter your email")]
        public string Email { get; set; }
        [Compare("ConfirmPassword")]
        [Display(Name ="Password")]
        [Required(ErrorMessage = "Please Enter your strong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = " Confirm Password")]
        [Required(ErrorMessage = "Please Enter your confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
