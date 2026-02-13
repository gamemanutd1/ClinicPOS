using System.Security.Claims;
using ClinicPOS.Domain.Authorization;

namespace ClinicPOS.Domain.Authorization;

public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Name);

            return userId == null ? Guid.Empty : Guid.Parse(userId);
        }
    }

    public string? Role =>
        _httpContextAccessor.HttpContext?
            .User?
            .FindFirstValue(ClaimTypes.Role);
}
