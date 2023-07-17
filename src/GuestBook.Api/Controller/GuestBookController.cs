using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Api.Controller;
public class GuestBookController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
