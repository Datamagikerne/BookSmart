using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class CreateTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher Teacher { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }

        ITeacherService TeacherService;
        ISubjectService subjectService;

        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public List<int> ChosenSubjectIds { get; set; }
        [BindProperty]
        public int InitialCheck { get; private set; }

        public SubjectTeacher SubjectTeacher { get; set; }
        public CreateTeacherModel(ITeacherService service, ISubjectService subjectService)
        {
            this.TeacherService = service;
            this.subjectService = subjectService;
        }
        
        public void OnGet()
        {
            Subjects = subjectService.GetSubjects();

        }
        public IActionResult OnPost()
        {
            Teachers = TeacherService.GetTeachers();
            foreach (var t in Teachers)
            {
                if (t.Initials == Teacher.Initials)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TeacherService.CreateTeacher(Teacher);
            Teacher = TeacherService.GetTeacher(Teacher.Initials);
            foreach (var cs in ChosenSubjectIds)
            {
                SubjectTeacher = new SubjectTeacher() { Initials = Teacher.Initials, SubjectId = cs };
                subjectService.AddSubjectToTeacher(SubjectTeacher);
            }
            return RedirectToPage("GetTeachers");
        }
    }
}

