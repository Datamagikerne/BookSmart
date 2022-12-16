using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        IBookService bookService;
        ITeacherService teacherService;

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty(SupportsGet = true)]
        public Teacher Teacher { get; set; }

        public IEnumerable<Book> Books { get; set; }
      
        public CreateBookModel(IBookService bService, ITeacherService teacherService)
        {
            this.bookService = bService;
            this.teacherService = teacherService;   
        }

        public void OnGet(string LoginDetails)
        {
            Teacher = teacherService.GetTeacher(LoginDetails);
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
            string a = Teacher.Initials;
            string url = $"https://localhost:7031/TeacherLayout/TeacherSite?LoginDetails={Teacher.Initials}";
            return Redirect(url);
        }
    }
}