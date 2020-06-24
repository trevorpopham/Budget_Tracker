﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Budget_Tracker.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterNewUserViewModel
    {
        [Required(ErrorMessage = "Enter a name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter an email.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string CheckingName { get; set; }
        [Required(ErrorMessage = "Enter an amount.")]
        public decimal CheckingAmount { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string SavingsName { get; set; }
        [Required(ErrorMessage = "Enter an amount.")]
        public decimal SavingsAmount { get; set; }

        [Required(ErrorMessage = "Enter an amount.")]
        public decimal IncomeAmount { get; set; }
        [Required(ErrorMessage = "Select a type.")]
        public IncomeType IncomeType { get; set; }
    }

    public class RegisterUserViewModel
    {
        public int HouseholdId { get; set; }
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter an email.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string CheckingName { get; set; }
        [Required(ErrorMessage = "Enter an amount.")]
        public decimal CheckingAmount { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        public string SavingsName { get; set; }
        [Required(ErrorMessage = "Enter an amount.")]
        public decimal SavingsAmount { get; set; }

        [Required(ErrorMessage = "Enter an amount.")]
        public decimal IncomeAmount { get; set; }
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
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}