using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Domain.ViewModels.Book;
using OnlineLibrary.Service.Interfaces;

namespace OnlineLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        //for all users
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookService.GetBooks();
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        //for all users
        [HttpGet]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _bookService.GetBookById(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        // for admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bookService.DeleteBook(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetBooks");
            }
            return RedirectToAction("Error");
        }
        // для редактирования и сохранения объектов
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var response = await _bookService.GetBookById(id);
            if(response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    await _bookService.CreateBook(model);
                }
                else
                {
                    await _bookService.Edit(model.Id, model);
                }
            }
            return RedirectToAction("GetBook");
        }
    }
}
