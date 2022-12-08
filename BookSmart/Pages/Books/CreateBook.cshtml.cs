using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        IBookService bookService;

        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
      
        public CreateBookModel(IBookService bService)
        {
            this.bookService = bService;
        }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            Books = bookService.GetBooks();
            foreach (var b in Books)
            {
                if (b.BookId == Book.BookId)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookService.CreateBook(Book);
            return RedirectToPage("GetBooks");
        }
    }
}