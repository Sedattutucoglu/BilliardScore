using BilliardScore.DTOs.Auth;

namespace BilliardScore.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);

    Task<string?> LoginAsync(LoginRequest request);
}