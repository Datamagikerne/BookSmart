using BookSmart.Models;



namespace BookSmart.Services.Interfaces
   
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();

        void CreateBook(Book book);
    }
}
