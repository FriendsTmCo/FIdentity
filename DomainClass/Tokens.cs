using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Users Tokens Data Base Table
/// </summary>
public record Tokens
{
    public Tokens()
    {

    }

    /// <summary>
    /// Token Id Primary Key
    /// </summary>
    [Key]
    public Guid TokenId { get; set; }

    /// <summary>
    /// Token Key For Set Key In Cookies Or Sessions
    /// </summary>
    [Display(Name = "Token Key")]
    [Required]
    public string TokenKey { get; set; }

    /// <summary>
    /// Token Value For Set Value In Cookies Or Sessions
    /// </summary>
    [Display(Name = "Token Value")]
    [Required]
    public string TokenValue { get; set; }

    /// <summary>
    /// Insert Token Date Time 
    /// Set Now Date Time
    /// </summary>
    [Display(Name = "Insert Token Date Time")]
    public DateTime InsertDate { get; set; }

    /// <summary>
    /// Expire (Delete) Token Date Time
    /// Set Expire Date Time 
    /// Like DateTime.Now().AddDays(29);
    /// </summary>
    [Display(Name = "Expire Token Date Time")]
    public DateTime ExpireDate { get; set; }

    /// <summary>
    /// User Id 
    /// </summary>
    [Required]
    public Guid UserId { get; set; }

    /// <summary>
    /// Login Log Id
    /// </summary>
    [Required]
    public Guid LogId { get; set; }

    //Relationships

    /// <summary>
    /// Relationships Table With Users
    /// </summary>
    public virtual Users Users { get; set; }

}

