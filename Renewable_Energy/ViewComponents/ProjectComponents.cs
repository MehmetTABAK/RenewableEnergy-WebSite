using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy_Web.ViewComponents
{
    public class ProjectComponents : ViewComponent
    {
        RenewableEnergyContext context = new();

        public IViewComponentResult Invoke()
        {
            List<ProjectCategoryDTO> projects = context.Projects
                .Include(w => w.Category)
                .OrderBy(x => Guid.NewGuid())
                .Take(6)
                .Select(project =>
                    new ProjectCategoryDTO
                    {
                        Id = project.Id,
                        Title = project.Title,
                        Body = project.Body,
                        ImageUrl = project.ImageUrl,
                        VideoUrl = project.VideoUrl,
                        ReferenceId = project.ReferenceId,
                        CategoryId = project.CategoryId,
                        CategoryName = project.Category != null ? string.Join(", ", project.Category.Name) : string.Empty,
                    }
                ).ToList();

            return View(projects);
        }
    }
}