using Microsoft.AspNetCore.Mvc;
using Renewable_Energy_DataAccess;

namespace Renewable_Energy_Web.ViewComponents
{
    public class FooterComponents : ViewComponent
    {
        RenewableEnergyContext context = new();

        public IViewComponentResult Invoke()
        {
            List<Renewable_Energy_Entities.AboutUs> aboutUs = context.AboutUs.ToList();
            return View(aboutUs);
        }
    }
}
