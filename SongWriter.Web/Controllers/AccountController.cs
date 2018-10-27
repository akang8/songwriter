using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SongWriter.Logic;
using SongWriter.Web.Infrastructure;
using SongWriter.Web.Models;

namespace SongWriter.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : AppControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public AccountController(AppLogicContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]AuthenticationAttempt model)
        {

            await this.httpContextAccessor.HttpContext.SignOutAsync();

            var isAuthenticated = this.appContext.Users.Authenticate(model.UserName, model.Password);

            if (isAuthenticated)
            {
                var user = this.appContext.Users.GetItem(model.UserName);

                // TODO: do I need to set an expiration?
                var claims = new[] {
                                    new Claim(ClaimTypes.Name, model.UserName),
                                    new Claim(ClaimTypes.SerialNumber, user.Id.ToString()),
                                    new Claim(ClaimTypes.Role, "User") };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await this.httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return Ok();
            }

            return Forbid();
        }

    }
}
