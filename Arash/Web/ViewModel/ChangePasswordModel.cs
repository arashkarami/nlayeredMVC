using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Arash.Membership.Site;

namespace Arash.Web.ViewModel
{
    public class ChangePasswordModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        [ValidatePasswordLength]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}