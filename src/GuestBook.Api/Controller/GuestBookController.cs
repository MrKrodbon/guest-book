using GuestBook.Models.Requests;
using GuestBook.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class GuestBookController : ControllerBase
{

    [HttpGet("comment")]
    public async Task<IActionResult> GetAsync([FromQuery] GuestBookReadRequestModel readRequestModel)
    {
        return Ok(new GuestBookResponseModel());
    }

    [HttpPost("comment")]
    public async Task<IActionResult> PostAsync([FromBody] GuestBookCreateRequestModel createRequestModel)
    {
        return Ok(new GuestBookResponseModel());
    }
}
