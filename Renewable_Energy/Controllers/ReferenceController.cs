using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy_Web.Controllers
{
    public class ReferenceController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Reference()
        {
            List<ReferenceProjectDTO> references = context.References.Include(w => w.Projects).ThenInclude(w => w.Category).ToList().Select(reference =>
            new ReferenceProjectDTO
            {
                Id = reference.Id,
                ReferenceName = reference.Name,
                ReferenceImageUrl = reference.ImageUrl,
                ProjectName = reference.Projects != null && reference.Projects.Any() ? string.Join(", ", reference.Projects.Select(w => w.Category.Name)) : string.Empty,
            }
            ).ToList();
            return View(references);
        }
    }
}
