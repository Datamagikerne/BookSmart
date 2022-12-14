using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class CreateTeacherModel : PageModel
    {
        ITeacherService teacherService;
        ISubjectService subjectService;
        ISubjectTeacherService stService;
        IClassTeacherService ctService;
        IClassService classService;

        [BindProperty]
        public Teacher Teacher { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }

        #region Subject Checkbox
        [BindProperty]
        public IEnumerable<Subject> Subjects { get; set; }
        [BindProperty]
        public List<int> ChosenSubjectIds { get; set; }
        public SubjectTeacher SubjectTeacher { get; set; }
        #endregion

        #region Class Checkbox
        public IEnumerable<Class> Classes { get; set; }
        [BindProperty]
        public List<int> ChosenClassIds { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        #endregion

        public CreateTeacherModel(ITeacherService tService, ISubjectService subjectService, 
                                  ISubjectTeacherService stServ, IClassTeacherService ctServ, IClassService classServ)
        {
            this.teacherService = tService;
            this.subjectService = subjectService;
            stService = stServ;
            ctService = ctServ;
            classService = classServ;
        }
        
        public void OnGet()
        {
            Subjects = subjectService.GetSubjects();
            Classes = classService.GetClasses();
        }

        public IActionResult OnPost()
        {
            Teachers = teacherService.GetTeachers();
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
            teacherService.CreateTeacher(Teacher);
            Teacher = teacherService.GetTeacher(Teacher.Initials);

            foreach (var cs in ChosenSubjectIds)
            {
                SubjectTeacher = new SubjectTeacher() { Initials = Teacher.Initials, SubjectId = cs };
                stService.CreateSubjectTeacher(SubjectTeacher);
            }

            foreach (var classid in ChosenClassIds)
            {
                ClassTeacher = new ClassTeacher() { ClassId = classid, Initials = Teacher.Initials };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            return RedirectToPage("GetTeachers");
        }
    }
}

