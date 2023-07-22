using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using GuestBookService.Data;
using Microsoft.EntityFrameworkCore;

namespace GuestBookService.Managers;
public class GuestBookManager
{
    private readonly GuestBookDbContext _guestBookContext;
    public GuestBookManager(GuestBookDbContext guestBookContext)
    {
        _guestBookContext = guestBookContext;
    }

    public async Task<GuestBookResponseModel?> ReadAsync(GuestBookReadRequestModel readRequestModel, CancellationToken cancellationToken)
    {
        GuestBookResponseModel? guestBookResponseModel = null;

        var searchRequestResult = await _guestBookContext.GuestBookEntity
            .Where(s => s.Id == readRequestModel.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (searchRequestResult != null)
        {
            guestBookResponseModel = new GuestBookResponseModel()
            {
                Id = searchRequestResult.Id,
                GuestName = searchRequestResult.GuestName,
                Comment = searchRequestResult.Comment,
                CommentDate = searchRequestResult.CommentDate
            };
        }

        return guestBookResponseModel;
    }
}
