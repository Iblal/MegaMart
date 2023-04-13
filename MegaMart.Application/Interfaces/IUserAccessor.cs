using MegaMart.Domain.Entities;
using System.Security.Claims;

namespace MegaMart.Application.Interfaces
{
    public interface IUserAccessor { ClaimsPrincipal User { get; } }
}
