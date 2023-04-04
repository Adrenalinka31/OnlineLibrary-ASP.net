using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;

namespace OnlineLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;


        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookRepository.Select();
            var response1 = await _bookRepository.GetByName("Грокаем алгоритмы");
            var response2 = await _bookRepository.Get(2);

            var book = new Book()
            {
                Name = "Тестовый вариант",
                Description = "shhjftjzjsz",
                BookYear = "2022",
                ISBN = "37647487",
                Category = Domain.Enum.TypeBook.ModelBook,
                ImageURL = "http/////"            
            };
            await _bookRepository.Create(book);
            await _bookRepository.Delete(book);

            return View(response);
        }
    }
}
