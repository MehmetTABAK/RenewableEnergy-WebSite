using Microsoft.AspNetCore.Mvc;
using Renewable_Energy_DataAccess;

namespace Renewable_Energy_Web.ViewComponents
{
    public class WorkAreaComponents : ViewComponent
    {
        RenewableEnergyContext context = new();

        public IViewComponentResult Invoke()
        {
            List<Renewable_Energy_Entities.WorkingArea> workingAreas = context.WorkingAreas.ToList();
            return View(workingAreas);
        }
    }
}
