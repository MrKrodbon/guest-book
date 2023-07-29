namespace GuestBook.Models.Responses;
public class GuestBookResponseModel
{
    public int Id { get; set; }

    public string GuestName { get; set; }

    public string Comment { get; set; }

    public DateTime CommentDate { get; set; }
}
