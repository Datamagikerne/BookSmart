using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        
        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
       
        IBookService BookService;
        public CreateBookModel(IBookService service)
        {
            this.BookService = service;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            Books = BookService.GetBooks();
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
            BookService.CreateBook(Book);
            return RedirectToPage("GetBooks");
        }
    }
}
