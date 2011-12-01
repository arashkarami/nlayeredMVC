using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Arash.Membership.Site;

namespace Arash.Web.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [ValidatePasswordLength]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}