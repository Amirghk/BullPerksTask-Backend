using BullPerksTask.Application.Interfaces.Authentication;
using BullPerksTask.Application.Models;

namespace BullPerksTask.Application.Queries;

public class GetJwtTokenAppService(IJwtTokenGenerator jwtTokenGenerator)
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public string? Execute(LoginModel model)
    {
        var token = _jwtTokenGenerator.GenerateToken(model);
        return token;
    }
}   
