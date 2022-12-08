using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Books
{
    public class CreateBookModel : PageModel
    {
        IBookService bookService;
        ISubjectService subjectService;

        [BindProperty]
        public Book Book { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public int SubjectId { get; set; }

        public CreateBookModel(IBookService bService, ISubjectService subjectService)
        {
            this.bookService = bService;
            this.subjectService = subjectService;
        }

        public void OnGet()
        {
            Subjects = subjectService.GetSubjects();
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
            Book.SubjectId = SubjectId;
            bookService.CreateBook(Book);
            return RedirectToPage("GetBooks");
        }
    }
}