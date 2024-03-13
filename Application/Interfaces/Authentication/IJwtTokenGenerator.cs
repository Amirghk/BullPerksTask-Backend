using BullPerksTask.Domain;

namespace BullPerksTask.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserModel model);
}
