using BookSmart.Models;



namespace BookSmart.Services.Interfaces
   
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();

        //IEnumerable<Book> GetBooks(string title, int year);

        void CreateBook(Book book);

        void DeleteBook(Book book);

        void UpdateBook(Book book);

        Book GetBook(int id);
    }
}
