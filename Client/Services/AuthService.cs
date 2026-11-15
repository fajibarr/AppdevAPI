using Client.Models;

namespace Client.Services;

public class AuthService
{
    public UserDto? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;

    // Returns null on success, or an error message
    public async Task<string?> RegisterAsync(RegisterModel model)
    {
        await Task.Delay(500); // pretend the network takes time
        if (model.Email == "taken@test.com")
            return "Email is already registered."; // lets you test the error display
        return null;
    }

    public async Task<string?> LoginAsync(LoginModel model)
    {
        await Task.Delay(500);
        if (model.Password != "password123")
            return "Invalid email or password.";

        CurrentUser = new UserDto { Email = model.Email, Username = "TestUser", Address = "Test Address" };
        return null;
    }

    public void Logout() => CurrentUser = null;
}