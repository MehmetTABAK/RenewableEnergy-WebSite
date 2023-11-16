using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy_Web.Controllers
{
    public class ProjectController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Project(string selectedCategory)
        {
            List<ProjectCategoryDTO> projects;

            if (string.IsNullOrEmpty(selectedCategory) || selectedCategory.ToLower() == "all")
            {
                projects = context.Projects.Include(w => w.Category).ToList().Select(project =>
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
            }
            else
            {
                projects = context.Projects.Include(w => w.Category)
                    .Where(project => project.Category != null && project.Category.Name.ToLower() == selectedCategory.ToLower())
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
            }
            ViewBag.SelectedCategory = selectedCategory;
            return View(projects);
        }

        public async Task<IActionResult> ProjectDetails(int id)
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            return View(project);
        }
    }
}
