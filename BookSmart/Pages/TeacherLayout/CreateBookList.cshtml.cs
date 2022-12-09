using BookSmart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Services.Interfaces;
using BookSmart.Services.EFServices;
using BookSmart.Services.Interfaces.CorrelationTables;

namespace BookSmart.Pages.TeacherLayout
{
    public class CreateBookListModel : PageModel
    {
        IBookService bookService;
        IClassService classService;
        IBookClassService bookClassService;
        public CreateBookListModel(IBookService bookService, IClassService classService, IBookClassService bookClassService)
        {
            this.bookService = bookService;
            this.classService = classService;
            this.bookClassService = bookClassService;
        }

        #region Book Checkbox
        public IEnumerable<Book> Books { get; set; }
        [BindProperty]
        public List<int> ChosenBookIds { get; set; }
        public BookClass BookClass { get; set; }
        #endregion

        public Class Class { get; set; }
        public string Initials { get; set; }
  
        public void OnGet(int cid, string tid)
        {
            Books = bookService.GetBooks();
            Class = classService.GetClass(cid);
            Initials = tid;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Class = classService.GetClass(Class.ClassId);
            foreach (var bc in ChosenBookIds)
            {
                BookClass = new BookClass() { ClassId = Class.ClassId, BookId = bc };
                bookClassService.CreateBookClass(BookClass);
            }
            return RedirectToPage($"TeacherSite?LoginDetails={Initials}");
        }
    }
}
