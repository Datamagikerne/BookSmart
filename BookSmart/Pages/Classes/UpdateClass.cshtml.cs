using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using BookSmart.Services.EFServices;
using BookSmart.Pages.Classes;

namespace BookSmart.Pages.Classes
{
        public class UpdateClassModel : PageModel
        {
            IClassService classService;
            IBookClassService bcService;
            IBookService bookService;
            IClassTeacherService ctService;
            ITeacherService teacherService;

            public UpdateClassModel(IClassService classService, IBookClassService bcService, IBookService bookService, IClassTeacherService ctService, ITeacherService teacherService)
            {
                this.classService = classService;
                this.bcService = bcService;
                this.bookService = bookService;
                this.ctService = ctService;
                this.teacherService = teacherService;
            }

            [BindProperty]
            public Teacher Teacher { get; set; }
            [BindProperty]
            public Book Book { get; set; }
            [BindProperty]
            public Class Class { get; set; }
            
            #region BookClass checkbox
            [BindProperty]
            public List<int> ChosenBooksIds { get; set; }
            public IEnumerable<Book> Books { get; set; }
            public IEnumerable<Class> Classes { get; set; }
            public BookClass BookClass { get; set; }
            public int Checker { get; set; }
            #endregion

            #region ClassTeacher checkbox
            [BindProperty]
            public List<string> ChosenTeacherIds { get; set; }
            public IEnumerable<Teacher> Teachers { get; set; }
            public ClassTeacher ClassTeacher { get; set; }
            public int Checker2 { get; set; }
            #endregion

            public void OnGet(int cid)
            {
                Class = classService.GetClass(cid);
                Books = bookService.GetBooks();
                Classes = classService.GetClasses();
                Teachers = teacherService.GetTeachers();
            }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            classService.UpdateClass(Class);
            Class = classService.GetClass(Class.ClassId);

            bcService.DeleteBooksClasses(Book.BookId);

            foreach (var bc in ChosenBooksIds)
            {
                BookClass = new BookClass() { BookId = Class.ClassId, BookId = bc };
                bcService.CreateBookClass(BookClass);
            }

            ctService.DeleteClassesTeachers(Class.ClassId);

            foreach (var ct in ChosenTeacherIds)
            {
                ClassTeacher = new ClassTeacher() { ClassId = Class.ClassId, Initials = ct };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            return RedirectToPage("GetClasses");
        }
    }
}