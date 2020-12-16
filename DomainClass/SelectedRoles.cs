using System;
using System.ComponentModel.DataAnnotations;

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
    public Guid UserId { get; set; }

    /// <summary>
    /// Role Id
    /// </summary>
    [Required]
    public Guid RoleId { get; set; }

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

