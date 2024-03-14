using BullPerksTask.Application.Models;
using BullPerksTask.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BullPerksTask.Presentation.Controllers;
[Route(EndpointRoutes.AuthContoller)]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly GetJwtTokenAppService _getJwtTokenAppService;
    public AuthController(GetJwtTokenAppService getJwtTokenAppService)
    {
        _getJwtTokenAppService = getJwtTokenAppService;
    }

    [HttpPost(EndpointRoutes.Login)]
    public IActionResult Login(LoginModel model) 
    {
        var result = _getJwtTokenAppService.Execute(model);

        return Ok(result);
    }
}
