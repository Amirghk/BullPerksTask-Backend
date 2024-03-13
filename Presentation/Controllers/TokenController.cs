using BullPerksTask.Application.Commands;
using BullPerksTask.Application.Queries;
using BullPerksTask.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BullPerksTask.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly CalculateTokenSupplyAndPersistToDatabaseAppService _calculateTokenSupplyAndPersistToDatabaseAppService;
    private readonly GetTokenInfoAppService _getTokenInfoAppService;

    public TokenController(CalculateTokenSupplyAndPersistToDatabaseAppService calculateTokenSupplyAndPersistToDatabaseAppService, GetTokenInfoAppService getTokenInfoAppService)
    {
        _calculateTokenSupplyAndPersistToDatabaseAppService = calculateTokenSupplyAndPersistToDatabaseAppService;
        _getTokenInfoAppService = getTokenInfoAppService;
    }

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> Post(UserModel model)
    {
        await _calculateTokenSupplyAndPersistToDatabaseAppService.Execute();
        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var token = await _getTokenInfoAppService.Execute(cancellationToken);

        return Ok(token);
    }
}
