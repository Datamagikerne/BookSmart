using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class CreateClassModel : PageModel
    {
        IClassService classService;
        IBookService bookService;
        IBookClassService bcService;
        IClassTeacherService ctService;
        ITeacherService teacherService;

        [BindProperty]
        public Class Class { get; set; }
        public IEnumerable<Class> Classes { get; set; }

        #region Book Checkbox
        public IEnumerable<Book> Books { get; set; }
        [BindProperty]
        public List<int> ChosenBookIds { get; set; }
        public BookClass BookClass { get; set; }
        #endregion

        #region Teacher Checkbox
        public IEnumerable<Teacher> Teachers { get; set; }
        [BindProperty]
        public List<string> ChosenTeacherIds { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        #endregion

        public CreateClassModel(IClassService cService, IBookClassService bcServ, IBookService bookService, IClassTeacherService ctServ, ITeacherService teacherServ)
        {
            this.classService = cService;
            this.bookService = bookService;
            bcService = bcServ;
            ctService = ctServ;
            teacherService = teacherServ;
        }
        public void OnGet()
        {
            Books = bookService.GetBooks();
            Teachers = teacherService.GetTeachers(); 
        }
        public IActionResult OnPost()
        {
            Classes = classService.GetClasses();
            foreach (var c in Classes)
            {
                if (c.ClassId == Class.ClassId)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            classService.CreateClass(Class);
            Class = classService.GetClass(Class.ClassId);

            foreach (var bc in ChosenBookIds)
            {
                BookClass = new BookClass() { ClassId = Class.ClassId , BookId = bc };
                bcService.CreateBookClass(BookClass);
            }

            foreach (var ct in ChosenTeacherIds)
            {
                ClassTeacher = new ClassTeacher() { ClassId = Class.ClassId, Initials = ct };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            return RedirectToPage("GetClasses");
        }
    }
}