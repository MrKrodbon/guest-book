using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GuestBookService.Managers;
public class GuestBookManager
{
    private readonly string connectionString = GetConnectionString();

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

    //TODO: Краще взяти підключення строку з АППсеттінгс
    static private string GetConnectionString()
    {
        // To avoid storing the connection string in your code,
        // you can retrieve it from a configuration file.
        return "Server=sql-server;Database=GuestBook;User Id=sa; Password=Guestbook24app;TrustServerCertificate=True";
    }
}
