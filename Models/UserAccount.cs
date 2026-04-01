using System.ComponentModel.DataAnnotations;

namespace cleo.Models;

public class UserAccount
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string? Password { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? GoogleId { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public AccountStatus Status { get; set; } = AccountStatus.Active;
}
