using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Renewable_Energy_DataAccess;
using System.Security.Claims;
using Renewable_Energy_Entities;

namespace Renewable_Energy_Web.Controllers
{
    public class LoginController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(Login us)
        {
            var admin = context.Logins.FirstOrDefault(x => x.UserName == us.UserName && x.Password == us.Password);
            if (admin != null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, us.Id.ToString()),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true, 
                    IsPersistent = true 
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), properties); 

                return RedirectToAction("Index", "Admin"); 

            }
            else 
            {
                return RedirectToAction("Index","Login");
            }
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); 

            return RedirectToAction("Index", "Login");
        }
    }
}




