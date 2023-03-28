using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.Models;

namespace OnlineLibrary.Controllers
{
    public class HelloStudentController : Controller
    {
        private static List<StudentViewModel> stud = new List<StudentViewModel>();
        public IActionResult Index()
        {
            return View(stud);
        }
        public IActionResult Create()
        {
            var studVm = new StudentViewModel();
            return View(studVm);
        }
        public IActionResult CreateStudent(StudentViewModel studentViewModel)
        {
            
            stud.Add(studentViewModel);
            return RedirectToAction(nameof(Index));
        }
        public String Hello()
        {
            return "Кто здесь?";
        }
    }
}
