using BullPerksTask.Application.Commands;
using BullPerksTask.Application.Queries;
using BullPerksTask.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BullPerksTask.Presentation.Controllers;
[Route(EndpointRoutes.TokenController)]
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

    [HttpPost(EndpointRoutes.Update)]
    [Authorize]
    public async Task<IActionResult> Update()
    {
        await _calculateTokenSupplyAndPersistToDatabaseAppService.Execute();
        return Ok();
    }


    [HttpGet(EndpointRoutes.GetData)]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var token = await _getTokenInfoAppService.Execute(cancellationToken);

        return Ok(token);
    }
}
