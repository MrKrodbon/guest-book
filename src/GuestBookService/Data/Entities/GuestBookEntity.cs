using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace GuestBookService.Data.Entities;
public class GuestBookEntity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "GuestName field is required")]
    [MaxLength(128, ErrorMessage = "GuestName must be no more than 128 characters")]
    public string? GuestName { get; set; }

    [Required(ErrorMessage = "Comment field is required")]
    [MaxLength(147, ErrorMessage = "GuestName must be no more than 147 characters")]
    public string? Comment { get; set; }

    public DateTime CommentDate { get; set; }

}
