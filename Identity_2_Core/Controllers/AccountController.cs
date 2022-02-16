using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity_2_Core.Controllers
{
    public class AccountController : Controller
    {
        [Authorize(Roles = "User,Client")]
        public IActionResult Secret()
        {
            //get current user name:

            //var currentUser = User.FindFirst(i => i.Type == ClaimTypes.Name).Value;

            //get current user claims:

            var currentUser = User.Claims;

            return View();
        }
        [Authorize(Policy = "AgePolicy")]
        public IActionResult PolicyBase()
        {
            return View();
        }
        public async Task<IActionResult> Authenticate()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, "5"),
                new Claim(ClaimTypes.Name, "RikoBgrff"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.DateOfBirth, "01/01/2000")
            };

            var driverClaims = new List<Claim>()
            {
                new Claim("Driver Licsence Id", "AZ1222134"),
                new Claim("Driver Licsence Type", "BC")
            };


            var passportIdentity = new ClaimsIdentity(claims, "CookieAuth");

            var driverLicsence = new ClaimsIdentity(driverClaims, "CookieAuth");

            var principle = new ClaimsPrincipal(new[] { passportIdentity, driverLicsence });

            await HttpContext.SignInAsync("CookieAuth", principle);

            return RedirectToAction("Index", "Home");

        }
    }
}
