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
    [Required]
    public string Password { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public AccountStatus Status { get; set; } = AccountStatus.Active;
}
