using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        IBookService bookService;

        [BindProperty]
        public Book Book { get; set; }

        public DeleteBookModel(IBookService bService)
        {
            this.bookService = bService;
            Book = new Book();
        }

       public void OnGet(int bid)
        {
            Book = bookService.GetBook(bid);
        }

        public IActionResult OnPost()
        {
            bookService.DeleteBook(Book);
            return RedirectToPage("GetBooks");
        }
    }
}