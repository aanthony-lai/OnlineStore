using OnlineStore.API.Interfaces;
using OnlineStore.API.Models;
using System.Security.Claims;

namespace OnlineStore.API.Services
{
	public class AuthenticationService : IMyAuthenticationService
	{
		public ClaimsPrincipal GetAuthenticated(AuthCredentials credentials)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name, credentials.Name),
				new Claim(ClaimTypes.Surname, credentials.LastName),
				new Claim(ClaimTypes.Email, credentials.Email)
			};
			var identity = new ClaimsIdentity(claims, "AnthonysCookieAuth");
			ClaimsPrincipal principal = new ClaimsPrincipal(identity);

			return principal;
		}
	}
}
