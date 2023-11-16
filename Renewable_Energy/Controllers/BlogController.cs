using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy_Web.Controllers
{
    public class BlogController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Blog()
        {
            List<BlogCategoryDTO> blog = context.Blogs.Include(w => w.Category).ToList().Select(blog =>
            new BlogCategoryDTO
            {
                Id = blog.Id,
                Title = blog.Title,
                Body = blog.Body,
                ImageUrl = blog.ImageUrl,
                CategoryId = blog.CategoryId,
                Time = blog.Time,
                Writer = blog.Writer,
                CategoryName = blog.Category != null ? string.Join(", ", blog.Category.Name) : string.Empty,
            }
            ).ToList();
            return View(blog);
        }
        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            return View(blog);
        }
    }
}
