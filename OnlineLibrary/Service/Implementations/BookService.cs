using Microsoft.EntityFrameworkCore;
using OnlineLibrary.DAL.Interfaces;
using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Domain.Enum;
using OnlineLibrary.Domain.Response;
using OnlineLibrary.Domain.ViewModels.Book;
using OnlineLibrary.Service.Interfaces;

namespace OnlineLibrary.Service.Implementations
{
    public class BookService : IBookService
    {

        private readonly IBaseRepository<Book> _bookRepository;

        public BookService (IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        //сервисы для использования в контроллерах
        public async Task<IBaseResponse<Book>> CreateBook(BookViewModel model, byte[] imageData)
        {          
            try
            {
                var book = new Book()
                {
                    Name = model.Name,
                    ISBN = model.ISBN,
                    Description = model.Description,
                    Category = (TypeBook)Convert.ToInt32(model.TypeBook),
                    ImageURL = model.ImageURL,
                    BookYear = model.BookYear
                };
                await _bookRepository.Create(book);

                return new BaseResponse<Book>()
                {
                    StatusCode = StatusCode.OK,
                    Data = book
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            
        }
        public async Task<IBaseResponse<bool>> DeleteBook(int id)
        {
            try
            {
                var book = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (book == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "User not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }
                await _bookRepository.Delete(book);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Book>> Edit(int id, BookViewModel model)
        {
            try
            {
                var book = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(book == null)
                {
                    return new BaseResponse<Book>()
                    {
                        Description = "Car not found",
                        StatusCode = StatusCode.BookNotFound
                    };
                }
                book.Name = model.Name;
                book.Description = model.Description;
                book.ISBN = model.ISBN;
                book.ImageURL = model.ImageURL;
                book.BookYear = model.BookYear;
                book.Category = (TypeBook)Convert.ToInt32(model.TypeBook);

                await _bookRepository.Update(book);

                return new BaseResponse<Book>()
                {
                    StatusCode = StatusCode.OK,
                    Data = book
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<BookViewModel>> GetBookById(int id)
        {            
            try
            {
                var book = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(book == null)
                {
                    return new BaseResponse<BookViewModel>()
                    {
                        Description = "Книга не найдена",
                        StatusCode = StatusCode.UserNotFound
                    };
                }
                var data = new BookViewModel()
                {
                    Name = book.Name,
                    Description = book.Description,
                    BookYear = book.BookYear,
                    TypeBook = book.Category.GetDisplayName(),
                    ISBN = book.ISBN,
                    ImageURL = book.ImageURL,
                    Image = book.Avatar,
                };

                return new BaseResponse<BookViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<BookViewModel>()
                {
                    Description = $"[GetBook] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

        }
        
        public IBaseResponse<List<Book>> GetBooks()
        {
            try
            {
                var books = _bookRepository.GetAll().ToList();
                if(!books.Any())
                {
                    return new BaseResponse<List<Book>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.BookNotFound
                    };
                }
                return new BaseResponse<List<Book>>()
                {
                    Data = books,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<Book>>()
                {
                    Description = $"[GetBooks] : {ex.Message}",
                     StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeBook[])
                    Enum.GetValues(typeof(TypeBook)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
