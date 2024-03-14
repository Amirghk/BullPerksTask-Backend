using System.ComponentModel.DataAnnotations;

namespace BullPerksTask.Application.Models;

public record LoginModel([Required(AllowEmptyStrings = false)] string UserName, [Required(AllowEmptyStrings = false)] string Password);
