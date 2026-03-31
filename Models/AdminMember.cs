using System.ComponentModel.DataAnnotations;

namespace cleo.Models;

public class AdminMember
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    public bool IsSuperAdmin { get; set; } = false;
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
}
