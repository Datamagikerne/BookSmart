using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.TeacherLayout
{
    public class CreateBookListModel : PageModel
    {
        private IBookService bookService;
        private IClassService classService;
        private IBookClassService bookClassService;
        private ITeacherService teacherService;

        public CreateBookListModel(IBookService bookService, IClassService classService, IBookClassService bookClassService, ITeacherService teacherService)
        {
            this.bookService = bookService;
            this.classService = classService;
            this.bookClassService = bookClassService;
            this.teacherService = teacherService;
        }

        #region Book Checkbox

        public IEnumerable<Book> Books { get; set; }

        [BindProperty]
        public List<int> ChosenBookIds { get; set; }

        public BookClass BookClass { get; set; }

        #endregion Book Checkbox

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public Class Class { get; set; }

        [BindProperty(SupportsGet = true)]
        public Teacher Teacher { get; set; }

        public void OnGet(int cid, string tid)
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                FilterCriteria = FilterCriteria.ToUpper();
                Books = bookService.GetBooks().Where(b => b.Title.ToUpper().Contains(FilterCriteria) || (b.Author.ToUpper().Contains(FilterCriteria) ||
                (Convert.ToString(b.Year).Contains(FilterCriteria) || (Convert.ToString(b.BookId).Contains(FilterCriteria)))));

                Class = classService.GetClass(ID);
                Teacher = teacherService.GetTeacher(tid);
            }
            else if(tid != null && cid != 0)
            {
                Books = bookService.GetBooks();
                Class = classService.GetClass(cid);
                Teacher = teacherService.GetTeacher(tid);
                TID = tid;
                ID = cid;
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            foreach (var bc in ChosenBookIds)
            {
                BookClass = new BookClass() { ClassId = Class.ClassId, BookId = bc };
                bookClassService.CreateBookClass(BookClass);
            }
            string url = $"https://localhost:7031/TeacherLayout/TeacherSite?LoginDetails={Teacher.Initials}";
            return Redirect(url);
        }
    }
}