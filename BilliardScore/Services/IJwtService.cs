namespace BilliardScore.Services
{
    public interface IJwtService
    {
        string GenerateToken(int userId, string userName);
    }
}