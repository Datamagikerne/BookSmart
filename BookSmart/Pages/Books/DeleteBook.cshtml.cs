using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;


namespace BookSmart.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }

        IBookService BookService;

        public DeleteBookModel(IBookService service)
        {
            this.BookService = service;
            Book = new Book();
        }

       public void OnGet(int bid)
        {
            Book = BookService.GetBook(bid);
        }

        public IActionResult OnPost()
        {
            BookService.DeleteBook(Book);
            return RedirectToPage("GetBooks");
        }
    }
}
