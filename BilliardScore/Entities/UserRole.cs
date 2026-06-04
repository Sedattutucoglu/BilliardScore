namespace BilliardScore.Entities;

public class UserRole
{
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public int RoleId { get; set; }

    public Role Role { get; set; } = null!;
}