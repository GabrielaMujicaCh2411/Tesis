using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Copreter.Domain.Service.Dto.Auth;
using Copreter.Utils;
using static Copreter.Utils.Keys;
using Copreter.Domain.Service.Contracts.Interfaces;

namespace Copreter.Controllers
{
    public class AuthController : Controller
    {
        #region Fields

        private readonly ILogger<AuthController> _logger;

        private readonly IAuthService _service;

        #endregion

        public AuthController(ILogger<AuthController> logger, IAuthService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var claimUser = HttpContext.User;

            if (claimUser != null && claimUser.Identity != null && claimUser.Identity.IsAuthenticated)
            {
                ////Get value from Session object.
                //ViewBag.Name = HttpContext.Session.GetString(sessionName);

                return RedirectToAction(ActionKeys.Index, ControllerKeys.Home);
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginDto dto, string? returnUrl = "")
        {
            if (!this.ModelState.IsValid)
            {
                return View(dto);
            }

            var result = await this._service.GetBy(dto);

            if (result == null)
            {
                ModelState.AddModelError("", "Invalid UserName or Password");
                ViewData["ValidateMessage"] = "user not found";
                return View();
            }

            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, result.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, result.IdRol.ToString()),
                    new Claim(ClaimTypes.Name, "Pepito")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

            var properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = dto.RememberMe
            };

            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), properties);

            //HttpContext.Session.SetString(SessionKeys.RolId, result.IdRol.ToString());

            return RedirectToAction(ActionKeys.IndexAdmin, ControllerKeys.Home);
        }
    }
}
