using GuestBook.Models.Requests;
using MassTransit;

namespace GuestBook.Service.Consumers;
public class GuestBookPostConsumer : IConsumer<GuestBookCreateRequestModel>
{
    public Task Consume(ConsumeContext<GuestBookCreateRequestModel> context)
    {
        return null;
        //TODO: Додати консьюмера для створення об'єкту
    }
}
