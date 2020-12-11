using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Login View Model 
/// </summary>
public record LoginViewModel
{
    /// <summary>
    /// Email or User Name For Login 
    /// </summary>
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(70, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(9, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// User Password
    /// </summary>
    [Display(Name = "Password")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(27, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(6, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}


/// <summary>
/// SignUp View Model
/// </summary>
public record SignupViewModel
{

    /// <summary>
    /// Email Address
    /// </summary>
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(70, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(9, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// User Name
    /// </summary>
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(70, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(3, ErrorMessage = "{0} Cant Smaller Than {1}")]
    public string UserName { get; set; }

    /// <summary>
    /// Phone Number
    /// </summary>
    [Display(Name = "Phone Number")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(13, ErrorMessage = "{0} Cant Be Upper Than {1}")]
    [MinLength(11, ErrorMessage = "{0} Cant Be Smaller Than {1}")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// User Password
    /// </summary>
    [Display(Name = "Password")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(27, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(6, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    /// <summary>
    /// Confirm Password
    /// </summary>
    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(27, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(6, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage = "Wrong Password (Passwords Not Confirmm)")]
    public string RePassword { get; set; }
}

/// <summary>
/// Activation View Model
/// </summary>
public record ActivationViewModel
{
    /// <summary>
    /// Email Address
    /// </summary>
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(70, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(9, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// User Activation Code
    /// </summary>
    [Display(Name = "Active Code")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(4, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(4, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [Range(4, 4)]
    public string ActiveCode { get; set; }
}


/// <summary>
/// Delete Account View Model
/// </summary>
public record DeleteAccountViewModel
{
    /// <summary>
    /// Email Address
    /// </summary>
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(70, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(9, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// User Activation Code
    /// Send Active Code For User And Resivce That For Delete Account
    /// </summary>
    [Display(Name = "Delete Code")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(4, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(4, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [Range(4, 4)]
    public string DeleteCode { get; set; }
}
