using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;

namespace BookSmart.Services.EFServices.CorrelationTables
{
    public class EFBookClassService : IBookClassService
    {
        BookSmartDBContext context;

        public EFBookClassService(BookSmartDBContext context)
        {
            this.context = context;
        }

        public void CreateBookClass(BookClass BookClass)
        {
            context.BookClasses.Add(BookClass);
            context.SaveChanges();
        }

        public void DeleteBookClass(BookClass BookClass)
        {
            context.BookClasses.Remove(BookClass);
            context.SaveChanges();
        }

        public void DeleteClassesBooks(int id)
        {
            foreach (var bc in context.BookClasses)
            {
                if (bc.ClassId == id)
                {
                    context.BookClasses.Remove(bc);
                }
            }
            context.SaveChanges();
        }

        public BookClass GetBookClass(int bookId, int classId)
        {
            foreach (var bc in context.BookClasses)
            {
                if(bc.ClassId== classId && bc.BookId == bookId)
                {
                    return bc;
                }
            }
            return null;
        }
    }
}