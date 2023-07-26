using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using GuestBookService.Data;
using GuestBookService.Data.Entities;
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

    public async Task<GuestBookResponseModel> CreateAsync(GuestBookCreateRequestModel createRequestModel, CancellationToken cancellationToken)
    {
        GuestBookEntity guestBookEntity = new GuestBookEntity()
        {
            GuestName = createRequestModel.GuestName,
            Comment = createRequestModel.Comment,
            CommentDate = createRequestModel.CommentDate
        };

        await _guestBookContext.AddAsync(guestBookEntity, cancellationToken);

        await _guestBookContext.SaveChangesAsync(cancellationToken);

        return new GuestBookResponseModel()
        {
            Id = guestBookEntity.Id,
            GuestName = guestBookEntity.GuestName,
            Comment = guestBookEntity.Comment,
            CommentDate = guestBookEntity.CommentDate
        };
    }
}
