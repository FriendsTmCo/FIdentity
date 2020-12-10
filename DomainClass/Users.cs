using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


/// <summary>
/// Users Data Base Table
/// </summary>
public record Users
{
    public Users()
    {

    }

    /// <summary>
    /// User Id Primary key
    /// Like UserName
    /// </summary>
    [Key]
    public int UserId { get; set; }

    /// <summary>
    /// Users UserName 
    /// </summary>
    [Display(Name = "User Name")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(50, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(5, ErrorMessage = "{0} Cant Smaller Than {1}")]
    public string UserName { get; set; }

    /// <summary>
    /// Users Full Name
    /// First Name 
    /// Last Name
    /// Like User First Name + User Last Name
    /// </summary>
    [Display(Name = "Name")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(50, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(5, ErrorMessage = "{0} Cant Smaller {1}")]
    public string Name { get; set; }

    /// <summary>
    /// Users Email Address
    /// Like Users@OutLook.com
    /// </summary>
    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(70, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(9, ErrorMessage = "{0} Cant Smaller Than {1}")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    /// <summary>
    /// Users Phone Number
    /// Like +98901000000000
    /// </summary>
    [Display(Name = "Phone Number")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(13, ErrorMessage = "{0} Cant Be Upper Than {1}")]
    [MinLength(11, ErrorMessage = "{0} Cant Be Smaller Than {1}")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// User Is Active Or Is Confirm With Phone Number Or Email Address
    /// </summary>
    [Display(Name = "IS Confrim")]
    [Required]
    public bool IsConfirm { get; set; }

    /// <summary>
    /// Users Active Code 
    /// Like 4425 
    /// its MaxLength 4 and Min Length 4 
    /// You Can Edit Length Of Active Code 
    /// </summary>
    [Display(Name = "Active Code")]
    [Required]
    public string ActiveCode { get; set; }

    /// <summary>
    /// User SignUp Date 
    /// Update When User Actived
    /// </summary>
    [Display(Name = "Active Date")]
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime ActiveDate { get; set; }

    //Relationships

    /// <summary>
    /// Relatioonships Table With Selected Roles
    /// </summary>
    public virtual List<SelectedRoles> SelectedRoles { get; set; }

    /// <summary>
    /// Relationships Table With Tokens
    /// </summary>
    public virtual List<Tokens> Tokens { get; set; }
}

