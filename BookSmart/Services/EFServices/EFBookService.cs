using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Services.EFServices
{
    public class EFBookService : IBookService
    {
        BookSmartDBContext context;

        public EFBookService(BookSmartDBContext context)
        {
            this.context = context; 
        }



        public IEnumerable<Book> GetAll()
        {
            return context.Books; 
        }
    }
}
