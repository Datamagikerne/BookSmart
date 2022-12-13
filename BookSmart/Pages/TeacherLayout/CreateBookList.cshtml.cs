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
        [BindProperty]
        public string TID { get; set; }

        public void OnGet(int cid, string tid)
        {
            Books = bookService.GetBooks();
            Class = classService.GetClass(cid);
            TID = tid;
            ID = cid;
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            foreach (var bc in ChosenBookIds)
            {
                BookClass = new BookClass() { ClassId = ID, BookId = bc };
                bookClassService.CreateBookClass(BookClass);
            }
            string url = $"https://localhost:7031/TeacherLayout/TeacherSite?LoginDetails={TID}";
            return Redirect(url);

        }
    }
}
