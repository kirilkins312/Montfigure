using System.ComponentModel.DataAnnotations;

namespace SHPTH.Data.ViewModels
{
    public class RegisterVM
    {


        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
        [Display(Name= "Email address")]
        [Required(ErrorMessage ="Email adress is required")]
        public string EmailAdress { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
        