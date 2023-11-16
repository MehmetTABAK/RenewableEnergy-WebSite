using Microsoft.AspNetCore.Mvc;
using Renewable_Energy.Models;
using System.Diagnostics;
using Renewable_Energy_DataAccess;
using Microsoft.EntityFrameworkCore;
using Renewable_Energy_Entities.DTOs;
using System.Text.Json;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}