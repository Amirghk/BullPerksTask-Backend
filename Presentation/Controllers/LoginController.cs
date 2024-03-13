using BullPerksTask.Application.Queries;
using BullPerksTask.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BullPerksTask.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly GetJwtTokenAppService _getJwtTokenAppService;
    public LoginController(GetJwtTokenAppService getJwtTokenAppService)
    {
        _getJwtTokenAppService = getJwtTokenAppService;
    }

    [HttpPost]
    public IActionResult Login(UserModel model) => Ok(_getJwtTokenAppService.Execute(model));
}
