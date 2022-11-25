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

        public EditBookModel(IBookService service)
        {
            bookService = service;
        }

        public IActionResult OnGet(int id)
        {
            Book = new Book();
            Book = bookService.GetBook(id);
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
