using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Domain.Response;
using OnlineLibrary.Domain.ViewModels.Book;

namespace OnlineLibrary.Service.Interfaces
{
    public interface IBookService
    {
        Task<IBaseResponse<IEnumerable<Book>>> GetBooks();
        Task<IBaseResponse<Book>> GetBookById(int id);
        Task<IBaseResponse<Book>> GetBookByName(string name);
        Task<IBaseResponse<bool>> DeleteBook(int id);
        Task<IBaseResponse<BookViewModel>> CreateBook(BookViewModel bookViewModel, byte[] imageData);
        Task<IBaseResponse<Book>> Edit(int id, BookViewModel model);
    }
}
