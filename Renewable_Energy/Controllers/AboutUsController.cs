using Microsoft.AspNetCore.Mvc;
using Renewable_Energy_DataAccess;

namespace Renewable_Energy_Web.Controllers
{
    public class AboutUsController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Contact()
        {
            List<Renewable_Energy_Entities.AboutUs> aboutUs = context.AboutUs.ToList();
            return View(aboutUs);
        }
        public IActionResult About()
        {
            List<Renewable_Energy_Entities.AboutUs> aboutUs = context.AboutUs.ToList();
            return View(aboutUs);
        }
    }
}
