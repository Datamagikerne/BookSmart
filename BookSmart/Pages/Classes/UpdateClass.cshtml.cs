using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using BookSmart.Services.EFServices;

namespace BookSmart.Pages.Classes
{
    public class UpdateClassModel : PageModel
    {
        IClassService classService;
        IClassTeacherService ctService;
        ITeacherService teacherService;
        IBookService bookService;
        IBookClassService bcService;


        public UpdateClassModel(IClassService classService, ITeacherService teacherService, IClassTeacherService ctService,
            IBookService bookService, IBookClassService bcService)
        {
            this.classService = classService;
            this.teacherService = teacherService;
            this.ctService = ctService;
            this.bookService = bookService;
            this.bcService = bcService;
        }

        [BindProperty]
        public Class Class { get; set; }
        [BindProperty]
        public Teacher Teacher { get; set; }
        [BindProperty]
        public Book Book { get; set; }

        public IEnumerable<Book> Books { get; set; }
        [BindProperty]
        public List <int> ChosenBookIds { get; set; }
        public BookClass BookClass { get; set; }



        [BindProperty]
        public List<int> ChosenInitials { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        [BindProperty]
        public List<string> ChosenCtIds { get; set; }
        [BindProperty]
        public ClassTeacher ClassTeacher { get; set; }
        public int Checker { get; set; }
        public int Checker2 { get; set; }
        




        public void OnGet(int cid)
        {
            Class = classService.GetClass(cid);
            Teachers = teacherService.GetTeachers();
            Classes = classService.GetClasses();
            Books = bookService.GetBooks();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            classService.UpdateClass(Class);
            Class = classService.GetClass(Class.ClassId);

            ctService.DeleteClassTeachers(Class.ClassId);

            foreach (var cs in ChosenCtIds)
            {
                ClassTeacher = new ClassTeacher() { Initials = cs, ClassId = Class.ClassId };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            
            bcService.DeleteBookClasses(Class.ClassId);

            foreach (var cs in ChosenBookIds)
            {
                BookClass = new BookClass() { BookId = cs, ClassId = Class.ClassId };
                bcService.CreateBookClass(BookClass);
            }









            return RedirectToPage("GetClasses");
        }
    }
}
