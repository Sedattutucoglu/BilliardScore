using BilliardScore.Data;
using BilliardScore.DTOs.Auth;
using BilliardScore.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BilliardScore.Helpers;

namespace BilliardScore.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var userExists = await _context.Users
            .AnyAsync(x => x.Email == request.Email || x.UserName == request.UserName);

        if (userExists)
        {
            return false;
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
            PasswordHash = PasswordHasher.HashPassword(request.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x =>
                 x.Email == request.EmailOrUserName ||
                 x.UserName == request.EmailOrUserName);
        if (user == null)
        {
            return false;
        }
        var isPasswordValid = PasswordHasher.VerifyPassword(request.Password, user.PasswordHash);
        return isPasswordValid;
    }
}