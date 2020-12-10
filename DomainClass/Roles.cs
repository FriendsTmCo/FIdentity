using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Roles Data Base Table
/// </summary>
public record Roles
{
    public Roles()
    {

    }

    /// <summary>
    /// Role Id Primary Key
    /// </summary>
    [Key]
    public int RoleId { get; set; }

    /// <summary>
    /// Role Title
    /// Liek Admin 
    /// Or User
    /// </summary>
    [Display(Name = "Role Title")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(10,ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(3,ErrorMessage = "{0} Cant Smaller Than {1}")]
    public string RoleTitle { get; set; }

    /// <summary>
    /// Role Name 
    /// Like Admin 
    /// Or User
    /// </summary>
    [Display(Name = "Role Name")]
    [Required(ErrorMessage = "{0} Cant Be Null")]
    [MaxLength(10, ErrorMessage = "{0} Cant Upper Than {1}")]
    [MinLength(3, ErrorMessage = "{0} Cant Smaller Than {1}")]
    public string RoleName { get; set; }

    //Relationships

    /// <summary>
    /// Realtionships With Selected Roles Table
    /// </summary>
    public virtual List<SelectedRoles> SelectedRoles { get; set; }
}

