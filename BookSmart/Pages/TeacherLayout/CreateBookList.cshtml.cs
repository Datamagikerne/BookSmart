using BookSmart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Services.Interfaces;
using BookSmart.Services.EFServices;
using BookSmart.Services.Interfaces.CorrelationTables;
using System.Security.Cryptography;

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



        
        [BindProperty]
        public int ID { get; set; }

        public void OnGet(int cid, string tid)
        {
            Books = bookService.GetBooks();
            Class = classService.GetClass(cid);
            Initials = tid;
            ID = cid;
        }
        //[BindProperty]
        public string Initials { get; set; }
        public IActionResult OnPost(int ID)
        {
            string b = Initials;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            int a = ID;
            
            foreach (var bc in ChosenBookIds)
            {
                BookClass = new BookClass() { ClassId = ID, BookId = bc };
                bookClassService.CreateBookClass(BookClass);
            }
            return RedirectToPage("/Classes/GetClasses");

        }
    }
}
