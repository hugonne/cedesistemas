using Cedesistemas.WheresMyStuff.Repos;
using Cedesistemas.WheresMyStuff.Website.Models;
using Cedesistemas.WheresMyStuff.Website.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cedesistemas.WheresMyStuff.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemsRepo _itemsRepo;

        public HomeController(
            ILogger<HomeController> logger,
            IItemsRepo itemsRepo)
        {
            _logger = logger;
            _itemsRepo = itemsRepo;
        }

        public IActionResult Index()
        {
            ViewData["Date"] = DateTime.Now.ToLongDateString();

            var items = _itemsRepo
                .GetAll()
                .Select(
                    a => new ItemViewModel
                    {
                        Id = a.Id,
                        Name = a.Name,
                        LocationId = a.LocationId,
                        LocationName = a.Location?.Name?.ToUpper()
                    });
            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _itemsRepo.GetById(id);
            return View(new ItemViewModel
            {
                Id = item.Id,
                Name = item.Name,
                LocationId = item.LocationId,
                LocationName = item.Location?.Name?.ToUpper()
            });
        }

        public IActionResult Privacy()
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
