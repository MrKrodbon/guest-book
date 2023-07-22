namespace GuestBook.Models.Requests;
public class GuestBookCreateRequestModel
{
    public string GuestName { get; set; }

    public string Comment { get; set; }

    public DateTime CommentDate { get; set; }
}
