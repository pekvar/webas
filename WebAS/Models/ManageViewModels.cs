using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebAS.Resources;

namespace WebAS.Models
{
    public class IndexViewModel
    {
        [Display(Name = "HasPassword", ResourceType = typeof(ModelResource))]
        public bool HasPassword { get; set; }

        [Display(Name = "Logins", ResourceType = typeof(ModelResource))]
        public IList<UserLoginInfo> Logins { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(ModelResource))]
        public string PhoneNumber { get; set; }

        [Display(Name = "TwoFactor", ResourceType = typeof(ModelResource))]
        public bool TwoFactor { get; set; }

        [Display(Name = "BrowserRemembered", ResourceType = typeof(ModelResource))]
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        [Display(Name = "CurrentLogins", ResourceType = typeof(ModelResource))]
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        [Display(Name = "OtherLogins", ResourceType = typeof(ModelResource))]
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        [Display(Name = "Purpose", ResourceType = typeof(ModelResource))]
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(ModelResource))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(ModelResource))]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "OldPassword", ResourceType = typeof(ModelResource))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(ModelResource))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmNewPassword", ResourceType = typeof(ModelResource))]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(ModelResource))]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code", ResourceType = typeof(ModelResource))]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(ModelResource))]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        [Display(Name = "SelectedProvider", ResourceType = typeof(ModelResource))]
        public string SelectedProvider { get; set; }

        [Display(Name = "Provider", ResourceType = typeof(ModelResource))]
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}