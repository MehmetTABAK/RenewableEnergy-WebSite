using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy_Web.Controllers
{
    public class BlogController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Blog(string selectedCategory)
        {
            List<BlogCategoryDTO> blogs;

            if (string.IsNullOrEmpty(selectedCategory) || selectedCategory.ToLower() == "all")
            {
                blogs = context.Blogs.Include(w => w.Category).ToList().Select(blog =>
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
            }
            else
            {
                blogs = context.Blogs.Include(w => w.Category)
                    .Where(blog => blog.Category != null && blog.Category.Name.ToLower() == selectedCategory.ToLower())
                    .Select(blog =>
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
            }
            ViewBag.SelectedCategory = selectedCategory;
            return View(blogs);      
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await context.Blogs.FirstOrDefaultAsync(b => b.Id == id);
            return View(blog);
        }
    }
}
