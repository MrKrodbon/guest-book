using GuestBook.Models.Requests;
using GuestBookService.Managers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestBookService.Consumers;
public class GuestBookPostConsumer : IConsumer<GuestBookCreateRequestModel>
{
    private readonly GuestBookManager _guestBookManager;

    public GuestBookPostConsumer(GuestBookManager guestBookManager)
    {
        _guestBookManager = guestBookManager;
    }
    public async Task Consume(ConsumeContext<GuestBookCreateRequestModel> context)
    {
        var result = await _guestBookManager.CreateAsync(context.Message, context.CancellationToken);

        await context.RespondAsync(result);
    }
}
