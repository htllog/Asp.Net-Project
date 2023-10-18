using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using InterfaceCore.Message.Commands.User;
using InterfaceCore.Message.Requests.User;

namespace InterfaceCore.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("get/all"), HttpGet]
    public async Task<IActionResult> GetAllUserAsync([FromQuery] GetUserRequest request)
    {
        var response = await _mediator.RequestAsync<GetUserRequest, GetUserResponse>(request).ConfigureAwait(false);
        
        return Ok(response);
    }
}