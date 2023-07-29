using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models.Requests;
public class GuestBookCreateRequestModel
{
    [Required]
    [StringLength(128)]
    public string? GuestName { get; set; }
    
    [Required]
    [StringLength(147)]
    public string? Comment { get; set; }

    public DateTime CommentDate { get; set; }
}
