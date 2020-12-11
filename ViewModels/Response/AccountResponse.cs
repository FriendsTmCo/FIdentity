/// <summary>
/// Signup Response
/// </summary>
public record SignUpResponse
{
    /// <summary>
    /// SignUp SuccessFully
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// System Exceptions
    /// </summary>
    public bool Exception { get; set; }

    /// <summary>
    /// User Exist
    /// </summary>
    public bool UserAlreadyExist { get; set; }
}

/// <summary>
/// Login Response
/// </summary>
public record LoginResponse
{
    /// <summary>
    /// Login Succes 
    /// Set Key and Value For Sessions or Cookies
    /// </summary>
    public Success Success { get; set; }

    /// <summary>
    /// System Exceptions
    /// </summary>
    public bool Exception { get; set; }

    /// <summary>
    /// Wrong Password
    /// </summary>
    public bool WrongPassword { get; set; }

    /// <summary>
    /// Not Found Any User
    /// </summary>
    public bool UserNotFound { get; set; }
}

public record ActivationResponse
{
    /// <summary>
    /// Actived User 
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Wrong Active Code 
    /// </summary>
    public bool WrongActiveCode { get; set; }

    /// <summary>
    /// System Exceptions
    /// </summary>
    public bool Exception { get; set; }
}

public record DeleteAccountResponse
{
    /// <summary>
    /// Delete User 
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Wrong DeleteCode Code 
    /// </summary>
    public bool WrongDeleteCode { get; set; }

    /// <summary>
    /// System Exceptions
    /// </summary>
    public bool Exception { get; set; }
}

/// <summary>
/// Success Type Response
/// </summary>
public record Success
{
    /// <summary>
    /// Is Success
    /// </summary>
    public bool IsSucces { get; init; } = true;

    /// <summary>
    /// Token Key 
    /// </summary>
    public string Key { get; init; }

    /// <summary>
    /// Token Value
    /// </summary>
    public string Value { get; init; }
}