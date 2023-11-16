using Microsoft.AspNetCore.Mvc;
using Renewable_Energy_DataAccess;

namespace Renewable_Energy_Web.Controllers
{
    public class BlogCategoryController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Index()
        {
            return View();
        }
    }
}
