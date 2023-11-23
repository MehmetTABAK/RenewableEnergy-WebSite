using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Renewable_Energy_DataAccess;
using Renewable_Energy_Entities;
using Renewable_Energy_Entities.DTOs;
using Renewable_Energy_Entities.DTOs.Admin;
using System.Data;

namespace Renewable_Energy_Web.Controllers
{
    public class AdminController : Controller
    {
        RenewableEnergyContext context = new();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Project()
        {
            List<ProjectUpdateDTO> categories = context.Projects.Include(w => w.Category).Include(w => w.Reference).ToList().Select(categories =>
            new ProjectUpdateDTO
            {
                Id = categories.Id,
                Title = categories.Title,
                Body = categories.Body,
                ImageUrl = categories.ImageUrl,
                VideoUrl = categories.VideoUrl,
                ReferenceId = categories.ReferenceId,
                ReferenceName = categories.Reference != null ? string.Join(",", categories.Reference.Name) : string.Empty,
                CategoryId = categories.CategoryId,
                CategoryName = categories.Category != null ? string.Join(",", categories.Category.Name) : string.Empty,
            }
            ).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult ProjectAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProjectAdd(ProjectUpdateDTO model)
        {
            Project project = new()
            {
                Title = model.Title,
                Body = model.Body,

                ImageUrl = model.ImageUrl,
                VideoUrl = model.VideoUrl,
                ReferenceId = model.ReferenceId,
                CategoryId = model.CategoryId,
            };

            context.Add(project);
            context.SaveChanges();

            return RedirectToAction("Project");
        }

        [HttpGet]
        public async Task<IActionResult> DropdownAddCategory(string name)
        {
            ViewData["Name"] = name;
            List<ProjectCategory> projectCategories = context.ProjectCategories.ToList();
            return PartialView("Partials/_DropdownAddCategory", projectCategories);
        }

        [HttpGet]
        public async Task<IActionResult> DropdownAddReference(string name)
        {
            ViewData["Name"] = name;
            List<Reference> projectReferences = context.References.ToList();
            return PartialView("Partials/_DropdownAddReference", projectReferences);
        }

        [HttpGet]
        public async Task<IActionResult> ProjectUpdate(int id)
        {
            var project = await context.Projects.FirstOrDefaultAsync(w => w.Id == id);
            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> ProjectUpdate(ProjectUpdateDTO pc)
        {
            var projectUpdate = await context.Projects.FirstOrDefaultAsync(w => w.Id == pc.Id);
            projectUpdate.Title = pc.Title;
            projectUpdate.Body = pc.Body;
            projectUpdate.ImageUrl = pc.ImageUrl;
            projectUpdate.VideoUrl = pc.VideoUrl;
            projectUpdate.ReferenceId = pc.ReferenceId;
            projectUpdate.CategoryId = pc.CategoryId;

            context.Update(projectUpdate);
            context.SaveChanges();
            return RedirectToAction("Project");
        }

        [HttpGet]
        public async Task<IActionResult> DropdownCategory(string name, int value)
        {
            ViewData["Name"] = name;
            ViewData["Value"] = value;
            List<ProjectCategory> projectCategories = context.ProjectCategories.ToList();
            return PartialView("Partials/_DropdownCategory", projectCategories);
        }

        [HttpGet]
        public async Task<IActionResult> DropdownReference(string name, int value)
        {
            ViewData["Name"] = name;
            ViewData["Value"] = value;
            List<Reference> projectReferences = context.References.ToList();
            return PartialView("Partials/_DropdownReference", projectReferences);
        }

        [HttpGet]
        public async Task<IActionResult> ProjectDelete(int id)
        {
            var project = await context.Projects.FirstOrDefaultAsync(w => w.Id == id);
            context.Projects.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Project");
        }

        public async Task<IActionResult> Blog()
        {
            List<BlogCategoryDTO> categories = context.Blogs.Include(w => w.Category).ToList().Select(categories =>
            new BlogCategoryDTO
            {
                Id = categories.Id,
                Title = categories.Title,
                Body = categories.Body,
                ImageUrl = categories.ImageUrl,
                CategoryId = categories.CategoryId,
                Time = categories.Time,
                Writer = categories.Writer,
                CategoryName = categories.Category != null ? string.Join(",", categories.Category.Name) : string.Empty,
            }
            ).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(BlogCategoryDTO model)
        {
            Blog blog = new()
            {
                Title = model.Title,
                Body = model.Body,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                Time = model.Time,
                Writer = model.Writer,
            };

            context.Add(blog);
            context.SaveChanges();

            return RedirectToAction("Blog");
        }

        [HttpGet]
        public async Task<IActionResult> DropdownAddBlogCategory(string name)
        {
            ViewData["Name"] = name;
            List<BlogCategory> blogCategories = context.BlogCategories.ToList();
            return PartialView("Partials/_DropdownAddBlogCategory", blogCategories);
        }

        [HttpGet]
        public async Task<IActionResult> BlogUpdate(int id)
        {
            var blog = await context.Blogs.FirstOrDefaultAsync(w => w.Id == id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> BlogUpdate(BlogCategoryDTO bc)
        {
            var blogUpdate = await context.Blogs.FirstOrDefaultAsync(w => w.Id == bc.Id);
            blogUpdate.Title = bc.Title;
            blogUpdate.Body = bc.Body;
            blogUpdate.ImageUrl = bc.ImageUrl;
            blogUpdate.Time = bc.Time;
            blogUpdate.Writer = bc.Writer;
            blogUpdate.CategoryId = bc.CategoryId;

            context.Update(blogUpdate);
            context.SaveChanges();
            return RedirectToAction("Blog");
        }

        [HttpGet]
        public async Task<IActionResult> DropdownCategoryBlog(string name, int value)
        {
            ViewData["Name"] = name;
            ViewData["Value"] = value;
            List<BlogCategory> blogCategories = context.BlogCategories.ToList();
            return PartialView("Partials/_DropdownCategoryBlog", blogCategories);
        }

        [HttpGet]
        public async Task<IActionResult> BlogDelete(int id)
        {
            var blog = await context.Blogs.FirstOrDefaultAsync(w => w.Id == id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Blog");
        }

        public async Task<IActionResult> Reference()
        {
            List<ReferenceProjectDTO> reference = context.References.Include(w => w.Projects).ThenInclude(w => w.Category).ToList().Select(reference =>
            new ReferenceProjectDTO
            {
                Id = reference.Id,
                ReferenceName = reference.Name,
                ReferenceImageUrl = reference.ImageUrl,
                ProjectName = reference.Projects != null && reference.Projects.Any() ? string.Join(", ", reference.Projects.Select(w => w.Category.Name)) : string.Empty,
            }
            ).ToList();

            return View(reference);
        }

        [HttpGet]
        public IActionResult ReferenceAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReferenceAdd(Reference model)
        {
            Reference refe = new()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Projects = model.Projects,
            };

            context.Add(refe);
            context.SaveChanges();

            return RedirectToAction("Reference");
        }

        [HttpGet]
        public async Task<IActionResult> ReferenceUpdate(int id)
        {
            var reference = await context.References.FirstOrDefaultAsync(w => w.Id == id);
            return View(reference);
        }

        [HttpPost]
        public async Task<IActionResult> ReferenceUpdate(Reference rp)
        {
            var referenceUpdate = await context.References.FirstOrDefaultAsync(w => w.Id == rp.Id);
            referenceUpdate.Name = rp.Name;
            referenceUpdate.ImageUrl = rp.ImageUrl;

            context.Update(referenceUpdate);
            context.SaveChanges();
            return RedirectToAction("Reference");
        }

        [HttpGet]
        public async Task<IActionResult> ReferenceDelete(int id)
        {
            var refe = await context.References.FirstOrDefaultAsync(w => w.Id == id);
            context.References.Remove(refe);
            context.SaveChanges();
            return RedirectToAction("Reference");
        }

        public async Task<IActionResult> WorkingArea()
        {
            List<WorkingArea> area = context.WorkingAreas.ToList().Select(area =>
            new WorkingArea
            {
                Id = area.Id,
                Title = area.Title,
                Body = area.Body,
                Details = area.Details,
                ImageUrl = area.ImageUrl,
            }
            ).ToList();

            return View(area);
        }

        [HttpGet]
        public IActionResult WorkAreaAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WorkAreaAdd(WorkingArea model)
        {
            WorkingArea area = new()
            {
                Title = model.Title,
                Body = model.Body,
                Details = model.Details,
                ImageUrl = model.ImageUrl,
            };

            context.Add(area);
            context.SaveChanges();

            return RedirectToAction("WorkingArea");
        }

        [HttpGet]
        public async Task<IActionResult> WorkingAreaUpdate(int id)
        {
            var area = await context.WorkingAreas.FirstOrDefaultAsync(w => w.Id == id);
            return View(area);
        }

        [HttpPost]
        public async Task<IActionResult> WorkingAreaUpdate(WorkingArea area)
        {
            var areaUpdate = await context.WorkingAreas.FirstOrDefaultAsync(w => w.Id == area.Id);
            areaUpdate.Title = area.Title;
            areaUpdate.Body = area.Body;
            areaUpdate.Details = area.Details;
            areaUpdate.ImageUrl = area.ImageUrl;

            context.Update(areaUpdate);
            context.SaveChanges();
            return RedirectToAction("WorkingArea");
        }

        [HttpGet]
        public async Task<IActionResult> WorkingAreaDelete(int id)
        {
            var working = await context.WorkingAreas.FirstOrDefaultAsync(w => w.Id == id);
            context.WorkingAreas.Remove(working);
            context.SaveChanges();
            return RedirectToAction("WorkingArea");
        }

        public async Task<IActionResult> AboutUs()
        {
            List<AboutUs> aboutUs = context.AboutUs.ToList().Select(aboutUs =>
            new AboutUs
            {
                Id = aboutUs.Id,
                Title = aboutUs.Title,
                Body = aboutUs.Body,
                ImageUrl = aboutUs.ImageUrl,
                VideoUrl = aboutUs.VideoUrl,
                Vision = aboutUs.Vision,
                Mission = aboutUs.Mission,
                Number = aboutUs.Number,
                Email = aboutUs.Email,
                Address = aboutUs.Address,
                Location = aboutUs.Location,
                WorkingTimes = aboutUs.WorkingTimes
            }
            ).ToList();

            return View(aboutUs);
        }

        [HttpGet]
        public async Task<IActionResult> AboutUsUpdate(int id)
        {
            var aboutUs = context.AboutUs.FirstOrDefault(w => w.Id == id);
            return View(aboutUs);
        }

        [HttpPost]
        public async Task<IActionResult> AboutUsUpdate(AboutUs au)
        {
            var aboutusUpdate = await context.AboutUs.FirstOrDefaultAsync(w => w.Id == au.Id);
            aboutusUpdate.Title = au.Title;
            aboutusUpdate.Body = au.Body;
            aboutusUpdate.ImageUrl = au.ImageUrl;
            aboutusUpdate.VideoUrl = au.VideoUrl;
            aboutusUpdate.Vision = au.Vision;
            aboutusUpdate.Mission = au.Mission;
            aboutusUpdate.Number = au.Number;
            aboutusUpdate.Email = au.Email;
            aboutusUpdate.Address = au.Address;
            aboutusUpdate.Location = au.Location;
            aboutusUpdate.WorkingTimes = au.WorkingTimes;

            context.Update(aboutusUpdate);
            context.SaveChanges();
            return RedirectToAction("AboutUs");
        }
    }
}
