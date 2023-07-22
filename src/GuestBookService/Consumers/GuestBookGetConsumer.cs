using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using GuestBookService.Managers;
using MassTransit;

namespace GuestBookService.Consumers;
public class GuestBookGetConsumer : IConsumer<GuestBookReadRequestModel>
{
    private readonly GuestBookManager _guestBookManager;

    public GuestBookGetConsumer(GuestBookManager guestBookManager)
    {
        _guestBookManager = guestBookManager;
    }

    public async Task Consume(ConsumeContext<GuestBookReadRequestModel> context)
    {
        var responseModel = await _guestBookManager.ReadAsync(context.Message, cancellationToken: context.CancellationToken);

        var serachRequestResult = new GuestBookResponseModel()
        {
            // TODO: Прописати повертаючий документ для null значень SearchRequestResult
        };
    }
}
