using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using GuestBook.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Service.Managers;
public class GuestBookManager
{
    private readonly GuestBookContext _guestBookContext;

    public GuestBookManager(GuestBookContext guestBookContext)
    {
        _guestBookContext = guestBookContext;
    }

    public async Task<GuestBookResponseModel?> ReadAsync(GuestBookReadRequestModel readRequestModel, CancellationToken cancellationToken)
    {
        GuestBookResponseModel? guestBookResponseModel = null;

        var searchRequestResult = await _guestBookContext.GuestBookEntities
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
