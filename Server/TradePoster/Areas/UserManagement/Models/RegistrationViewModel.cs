using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradePoster.Areas.UserManagement.Models
{
    public class RegistrationViewModel
    {
    }

    public class AuthenticationModel
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public string Role { get; set; }
        public bool RememberMe { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
		public bool EmailVerified { get; set; }
		public string Source { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
