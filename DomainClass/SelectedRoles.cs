using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// User Selected Roles Data Base Table
/// </summary>
public record SelectedRoles
{
    public SelectedRoles()
    {

    }

    /// <summary>
    /// Selected Id Primary Key
    /// </summary>
    [Key]
    public int SelectedId { get; set; }

    /// <summary>
    /// User Id 
    /// </summary>
    [Required]
    public int UserId { get; set; }

    /// <summary>
    /// Role Id
    /// </summary>
    [Required]
    public int RoleId { get; set; }

    //Relationships 

    /// <summary>
    /// Relationships With Roles
    /// </summary>
    public virtual Roles Roles { get; set; }

    /// <summary>
    /// Relationships With Users Table
    /// </summary>
    public virtual Users Users { get; set; }
}

