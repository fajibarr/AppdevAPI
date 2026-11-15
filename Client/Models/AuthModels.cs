using System.ComponentModel.DataAnnotations;

namespace Client.Models;

public class RegisterModel
{
    [Required, EmailAddress] public string Email { get; set; } = "";
    [Required] public string Username { get; set; } = "";
    [Required] public string Address { get; set; } = "";
    [Required, MinLength(6)] public string Password { get; set; } = "";
}

public class LoginModel
{
    [Required, EmailAddress] public string Email { get; set; } = "";
    [Required] public string Password { get; set; } = "";
}

public class UserDto
{
    public string Email { get; set; } = "";
    public string Username { get; set; } = "";
    public string Address { get; set; } = "";
}