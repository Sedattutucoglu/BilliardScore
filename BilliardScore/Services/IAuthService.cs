using BilliardScore.DTOs.Auth;

namespace BilliardScore.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);

    Task<bool> LoginAsync(LoginRequest request);
}