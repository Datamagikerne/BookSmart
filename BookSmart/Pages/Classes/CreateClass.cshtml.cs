using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class CreateClassModel : PageModel
    {
        [BindProperty]
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }

        IClassService ClassService;
        ITeacherService TeacherService;
        IClassTeacherService CtService;
        IBookService BookService;
        IBookClassService BookClassService;

        [BindProperty]
        public string InitialCheck { get; private set; }
        public CreateClassModel
            (
            IClassService service,
            ITeacherService teacherService,
            IClassTeacherService ctService,
            IBookService bookService,
            IBookClassService bookClassService
            )
        {
            this.ClassService = service;
            TeacherService = teacherService;
            CtService = ctService;
            BookService = bookService;
            BookClassService = bookClassService;
        }
        #region Teacher Checkbox

        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Class> Classes { get; set; }

        [BindProperty]
        public List<int> ChoosenClassIds { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        #endregion
        public void OnGet()
        {
            Classes = ClassService.GetClasses();
            Teachers = TeacherService.GetTeachers();
        }
        public IActionResult OnPost()
        {
            Classes = ClassService.GetClasses();
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
            ClassService.CreateClass(Class);

            Class = ClassService.GetClass(Class.ClassId);
            foreach (var classid in ChoosenClassIds)
            {
                ClassTeacher = new ClassTeacher() { ClassId = classid, Initials = Teacher.Initials };
                CtService.CreateClassTeacher(ClassTeacher);
            }



            return RedirectToPage("GetClasses");
        }
    }
}
