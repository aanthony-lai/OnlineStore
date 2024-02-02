using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Interfaces;
using OnlineStore.API.Models;

namespace OnlineStore.API.Controllers
{
	[Route("api/authenticate")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMyAuthenticationService _AuthService;
		public AuthController(IMyAuthenticationService myAuthenticationService)
		{
			_AuthService = myAuthenticationService;
		}

		[HttpPost]
		public async Task<ActionResult> Authenticate(AuthCredentials credentials)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var claimsPrincipal = _AuthService.GetAuthenticated(credentials);
			await HttpContext.SignInAsync("AnthonysCookieAuth", claimsPrincipal);

			return NoContent();
		}

	}
}
