using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using MegaMart.Application.Interfaces;

namespace MegaMart.Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _accessor;

        public UserAccessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        public ClaimsPrincipal User => _accessor.HttpContext.User;
    }
}
