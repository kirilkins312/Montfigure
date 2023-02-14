using System.ComponentModel.DataAnnotations;

namespace SHPTH.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email adress is required")]
        public string EmailAdress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
