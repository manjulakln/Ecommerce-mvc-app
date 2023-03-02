using System.ComponentModel.DataAnnotations;
namespace Ecommercemvcapp.Data.ViewModels
{
    public class LoginVM
    {
       [Required,Display(Name ="Email Address")]
        public string Emailaddress { get; set; }
        [Required,DataType(DataType.Password)]  
        public string Password { get; set; }
    }
}
