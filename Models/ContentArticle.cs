using System.ComponentModel.DataAnnotations;

namespace cleo.Models;

public class ContentArticle
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Category { get; set; } = "General";
    [Required]
    public string Content { get; set; } = string.Empty;
    public string Status { get; set; } = "Published"; // Published, Draft
    public int Views { get; set; } = 0;
    public DateTime PublishDate { get; set; } = DateTime.UtcNow;
}
