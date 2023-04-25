using OnlineLibrary.Domain.Entity;
using OnlineLibrary.Domain.Response;
using OnlineLibrary.Domain.ViewModels.Book;

namespace OnlineLibrary.Service.Interfaces
{
    public interface IBookService
    {
        IBaseResponse<List<Book>> GetBooks();
        Task<IBaseResponse<BookViewModel>> GetBookById(int id);
        Task<IBaseResponse<bool>> DeleteBook(int id);
        Task<IBaseResponse<Book>> CreateBook(BookViewModel model, byte[] imageData);
        Task<IBaseResponse<Book>> Edit(int id, BookViewModel model);
    }
}
