using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class GetBooksModel : PageModel
    {
        public IEnumerable<Book> Books { get; set; }

        private IBookService context;

        public GetBooksModel(IBookService service)
        {
            context = service;
        }

        public void OnGet()
        {
            Books = context.GetBooks();
        }
    }
}
