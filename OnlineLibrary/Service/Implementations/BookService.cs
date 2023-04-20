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
        
        public async Task<IBaseResponse<BookViewModel>> CreateBook(BookViewModel bookViewModel, byte[] imageData)
        {
            var baseResponse = new BaseResponse<BookViewModel>();
            try
            {
                var book = new Book()
                {
                    Name = bookViewModel.Name,
                    ISBN = bookViewModel.ISBN,
                    Description = bookViewModel.Description,
                    Category = (TypeBook)Convert.ToInt32(bookViewModel.Category),
                    ImageURL = bookViewModel.ImageURL,
                    BookYear = bookViewModel.BookYear
                };
                await _bookRepository.Create(book);
            }
            catch (Exception ex)
            {
                return new BaseResponse<BookViewModel>()
                {
                    Description = $"[CreateBook] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<bool>> DeleteBook(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var book = await _bookRepository.Get(id);
                if (book == null)
                {
                    baseResponse.Description = "Книга не найдена";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                await _bookRepository.Delete(book);
                return baseResponse;
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
            var baseResponse = new BaseResponse<Book>();
            try
            {
                var book = await _bookRepository.Get(id);
                if(book == null)
                {
                    baseResponse.StatusCode= StatusCode.BookNotFound;
                    baseResponse.Description = "Книга не найдена";
                    return baseResponse;
                }

                book.Name = model.Name;
                book.Description = model.Description;
                book.ISBN = model.ISBN;
                book.ImageURL = model.ImageURL;
                book.BookYear = model.BookYear;
                //book.Category = model.Category;
                await _bookRepository.Update(book);

                return baseResponse;


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

        public async Task<IBaseResponse<Book>> GetBookById(int id)
        {
            var baseResponse = new BaseResponse<Book>();
            try
            {
                var book = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(book == null)
                {
                    baseResponse.Description = "Книга не найдена";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = book;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[GetBookById] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<Book>> GetBookByName(string name)
        {
            var baseResponse = new BaseResponse<Book>();
            try
            {
                var book = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
                if (book == null)
                {
                    baseResponse.Description = "Книга по названию не найдена";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                baseResponse.Data = book;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[GetBookByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<IEnumerable<Book>>> GetBooks()
        {
            var baseResponse = new BaseResponse<IEnumerable<Book>>();
            try
            {
                var books = await _bookRepository.GetAll().ToListAsync();
                if(books.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                baseResponse.Data = books;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Book>>()
                {
                    Description = $"[GetBooks] : {ex.Message}",
                     StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
