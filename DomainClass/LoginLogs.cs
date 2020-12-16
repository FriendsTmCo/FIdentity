using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Users Login Logs Data Base
/// </summary>
public record LoginLogs
{
    public LoginLogs()
    {

    }

    /// <summary>
    /// Log Id Primary Key
    /// </summary>
    [Key]
    public Guid LogId { get; set; }

    /// <summary>
    /// Local Device Ip Address
    /// </summary>
    [Required]
    public string LocalIpAddress { get; set; }

    /// <summary>
    /// Remote Device Ip Address
    /// </summary>
    [Required]
    public string RemoteIpAddress { get; set; }

    /// <summary>
    /// Local Device Connection Port 
    /// </summary>
    [Required]
    public string LocalPort { get; set; }

    /// <summary>
    /// Remote Device Connection Port
    /// </summary>
    [Required]
    public string RemotePort { get; set; }

    /// <summary>
    /// Set Date Time Token
    /// </summary>
    [Required]
    public DateTime SetDate { get; set; }

    /// <summary>
    /// Token Id Relationshis
    /// </summary>
    [Required]
    public Guid TokenId { get; set; }

}

