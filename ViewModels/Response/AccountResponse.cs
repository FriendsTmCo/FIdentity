/// <summary>
/// Signup Response
/// </summary>
public enum SignUpResponse
{
    /// <summary>
    /// SignUp SuccessFully
    /// </summary>
    Success = 0,

    /// <summary>
    /// System Exceptions
    /// </summary>
    Exception = -2,

    /// <summary>
    /// User Exist
    /// </summary>
    UserAlreadyExist = -3
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
    /// Action Status
    /// </summary>
    public LoginStatus Status { get; set; }
}

/// <summary>
/// Login Status
/// </summary>
public enum LoginStatus
{
    Success = 0,
    Exception = -2,
    WrongPassword = -3,
    UserNotFound = -4
}

public enum ActivationResponse
{
    /// <summary>
    /// Actived User 
    /// </summary>
    Success = 0,

    /// <summary>
    /// Wrong Active Code 
    /// </summary>
    WrongActiveCode = -1,

    /// <summary>
    /// System Exceptions
    /// </summary>
    Exception = -2
}

public enum DeleteAccountResponse
{
    /// <summary>
    /// Delete User 
    /// </summary>
    Success = 0,

    /// <summary>
    /// Wrong DeleteCode Code 
    /// </summary>
    WrongDeleteCode = -1,

    /// <summary>
    /// System Exceptions
    /// </summary>
    Exception = -2
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