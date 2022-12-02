using BookSmart.Models;

namespace BookSmart.Services.Interfaces.CorrelationTables
{
    public interface IBookClassService
    {
        void CreateBookClass(BookClass BookClass);
        void DeleteBookClass(BookClass BookClass);
        BookClass GetBookClass(int bookId, int classId);

    }
}
