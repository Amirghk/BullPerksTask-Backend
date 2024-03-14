using BullPerksTask.Application.Models;

namespace BullPerksTask.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(LoginModel model);
}
