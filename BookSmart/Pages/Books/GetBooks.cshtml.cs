using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class GetBooksModel : PageModel
    {
        IBookService bookService;

        public IEnumerable<Book> Books { get; set; }

        public Book Book { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetBooksModel(IBookService bService)
        {
            bookService = bService;
        }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Books = bookService.GetBooks().Where(b => b.Title.Contains(FilterCriteria) || (b.Author.Contains(FilterCriteria) || 
                (Convert.ToString(b.Year).Contains(FilterCriteria) || (Convert.ToString(b.BookId).Contains(FilterCriteria)))));
            }
            else
                Books = bookService.GetBooks();
        }
    }
}