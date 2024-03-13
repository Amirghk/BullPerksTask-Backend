using BullPerksTask.Application.Interfaces.Authentication;
using BullPerksTask.Domain;

namespace BullPerksTask.Application.Queries;

public class GetJwtTokenAppService(IJwtTokenGenerator jwtTokenGenerator)
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public string? Execute(UserModel model)
    {
        var token = _jwtTokenGenerator.GenerateToken(model);
        return token;
    }
}   
