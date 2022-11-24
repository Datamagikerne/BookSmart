using BookSmart.Models;



namespace BookSmart.Services.Interfaces
   
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
    }
}
