using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Models;
using System.Diagnostics;

namespace OnlineLibrary.Controllers
{
    public class HomeController : Controller
    {
        
        
        public IActionResult Index()
        {
            return View();
        }

        

        
    }
}