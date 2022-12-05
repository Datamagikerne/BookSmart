using BookSmart.Services.Interfaces.CorrelationTables;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;

namespace BookSmart.Pages
{
    public class KoordinatorLoginModel : PageModel
    {
        IClassService classService;
        ISubjectService subjectService;
        ITeacherService teacherService;
        public KoordinatorLogin(IClassService classServ, ISubjectService subjectServ, ITeacherService teacherServ)
        {
            classService = classServ;
            subjectService = subjectServ;
            teacherService = teacherServ;
        }
        [BindProperty]
        public Class Class { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }

        public List<Class> Classes { get; private set; }
        public List<Subject> Subjects { get; private set; }
        public List<Teacher> Teachers { get; private set; }
        public void OnGet()
        {
            Class = new Class();
            Subject = new Subject();
            Teacher = new Teacher();
            Classes = classService.GetClass();
            Subjects = subjectService.GetSubject();
            Teachers = teacherService.GetTeacher();
        }
        public void OnPost()
        {

        }
    }
}
