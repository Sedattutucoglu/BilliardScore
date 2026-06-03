using BilliardScore.Entities;

public class PlayerProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? NickName { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? ProfileImageUrl { get; set; }

    public DateTime? BirthDate { get; set; }

    public User User { get; set; } = null!;
}