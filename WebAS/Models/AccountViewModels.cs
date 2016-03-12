using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAS.Resources;

namespace WebAS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(ModelResource))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        [Display(Name = "ReturnUrl", ResourceType = typeof(ModelResource))]
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        [Display(Name = "Providers", ResourceType = typeof(ModelResource))]
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        [Display(Name = "ReturnUrl", ResourceType = typeof(ModelResource))]
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(ModelResource))]
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        [Display(Name = "Provider", ResourceType = typeof(ModelResource))]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(ModelResource))]
        public string Code { get; set; }

        [Display(Name = "ReturnUrl", ResourceType = typeof(ModelResource))]
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser", ResourceType = typeof(ModelResource))]
        public bool RememberBrowser { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(ModelResource))]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(ModelResource))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(ModelResource))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ModelResource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(ModelResource))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ModelResource))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ModelResource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(ModelResource))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(ModelResource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(ModelResource))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Code", ResourceType = typeof(ModelResource))]
        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(ModelResource))]
        public string Email { get; set; }
    }
}
