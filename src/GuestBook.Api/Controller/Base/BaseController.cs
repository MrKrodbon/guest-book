using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Api.Controller.Base;

public class BaseController : ControllerBase
{
    private readonly IBus _bus;

    protected BaseController(IServiceProvider serviceProvider)
    {
        _bus = serviceProvider.GetRequiredService<IBus>();
    }

    protected async Task<TResponse> ResponseAsync<TRequest, TResponse>(TRequest request)
        where TRequest : class
        where TResponse : class
    {
        var requestClient = _bus.CreateRequestClient<TRequest>();

        var result = await requestClient.GetResponse<TResponse>(request, HttpContext.RequestAborted);

        return result.Message;
    }
}
