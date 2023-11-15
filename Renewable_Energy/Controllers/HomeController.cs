using Microsoft.AspNetCore.Mvc;
using Renewable_Energy.Models;
using System.Diagnostics;
using Renewable_Energy_DataAccess;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_Entities.DTOs;

namespace Renewable_Energy.Controllers
{
    public class HomeController : Controller
    {
        RenewableEnergyContext context = new();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            List<Renewable_Energy_Entities.AboutUs> aboutUs = context.AboutUs.ToList();
            return View(aboutUs);
        }

        public IActionResult About()
        {
            List<Renewable_Energy_Entities.AboutUs> aboutUs = context.AboutUs.ToList();
            return View(aboutUs);
        }

        public IActionResult Blog()
        {
            List<Renewable_Energy_Entities.Blog> blogs = context.Blogs.ToList();
            return View(blogs);
        }

        public IActionResult Project()
        {
            List<Renewable_Energy_Entities.Project> projects = context.Projects.ToList();
            return View(projects);
        }

        public IActionResult WorkingPlaces()
        {
            List<Renewable_Energy_Entities.WorkingArea> workingAreas = context.WorkingAreas.ToList();
            return View(workingAreas);
        }

        public IActionResult ProjectDetails()
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();
        }

        public IActionResult Reference()
        {
            List<ReferenceProjectDTO> references = context.References.Include(w => w.Projects).ThenInclude(w=>w.Category).ToList().Select(reference =>
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}