using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceCore.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Hello()
    {
        return "Hello demo";
    }
}