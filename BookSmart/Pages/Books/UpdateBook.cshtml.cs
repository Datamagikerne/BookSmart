using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;

namespace BookSmart.Pages.Books
{
    public class EditBookModel : PageModel
    {
        private IBookService bookService;

        [BindProperty]
        public Book Book { get; set; }

        public EditBookModel(IBookService bService)
        {
            bookService = bService;
        }

        public IActionResult OnGet(int bid)
        {
            Book = new Book();
            Book = bookService.GetBook(bid);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bookService.UpdateBook(Book);
            return RedirectToPage("GetBooks");
        }
    }
}