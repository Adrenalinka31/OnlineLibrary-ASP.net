using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Models;
using System.Diagnostics;

namespace OnlineLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Book book = new Book()
            {
                Name = "Algoritm bebri", 
                Description = "jkrdfgbdfkjdrfjnhd",
                BookYear = "2019"
                
                
            };
            return View(book);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}