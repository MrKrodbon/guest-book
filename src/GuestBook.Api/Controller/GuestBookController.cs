using GuestBook.Api.Controller.Base;
using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class GuestBookController : BaseController
{
    public GuestBookController(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    [HttpGet("comment")]
    public async Task<IActionResult> GetAsync([FromQuery] GuestBookReadRequestModel readRequestModel)
    {

        var response = await ResponseAsync<GuestBookReadRequestModel, SearchRequestResultModel>(readRequestModel);

        if (response.ResponseModel != null)
        {
            return Ok(response.ResponseModel);
        }
        else
        {
            return NotFound();
        }

    }

    [HttpPost("comment")]
    public async Task<IActionResult> PostAsync([FromBody] GuestBookCreateRequestModel createRequestModel)
    {
        var response = await ResponseAsync<GuestBookCreateRequestModel, GuestBookResponseModel>(createRequestModel);

        return Ok(response);
    }
}
