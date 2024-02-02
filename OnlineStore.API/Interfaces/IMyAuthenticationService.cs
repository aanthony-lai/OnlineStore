using OnlineStore.API.Models;
using System.Security.Claims;

namespace OnlineStore.API.Interfaces
{
	public interface IMyAuthenticationService
	{
		ClaimsPrincipal GetAuthenticated(AuthCredentials credentials);
	}
}
