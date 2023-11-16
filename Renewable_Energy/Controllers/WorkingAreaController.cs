using Microsoft.AspNetCore.Mvc;
using Renewable_Energy_DataAccess;

namespace Renewable_Energy_Web.Controllers
{
    public class WorkingAreaController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult WorkingPlaces()
        {
            List<Renewable_Energy_Entities.WorkingArea> workingAreas = context.WorkingAreas.ToList();
            return View(workingAreas);
        }
    }
}
