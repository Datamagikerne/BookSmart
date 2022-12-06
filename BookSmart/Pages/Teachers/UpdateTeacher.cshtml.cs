using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class UpdateTeacherModel : PageModel
    {
        ITeacherService TeacherService;
        ISubjectTeacherService stService;
        ISubjectService subjectService;
        IClassTeacherService ctService;
        IClassService ClassService;

        public UpdateTeacherModel(ITeacherService TeacherService, ISubjectTeacherService stService, ISubjectService subjectService, IClassTeacherService ctService, IClassService ClassService)
        {
            this.TeacherService = TeacherService;
            this.stService = stService;
            this.subjectService = subjectService;
            this.ctService = ctService;
            this.ClassService = ClassService;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        #region SubjectTeacher checkbox
        [BindProperty]
        public List<int> ChosenSubjectIds { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public SubjectTeacher SubjectTeacher { get; set; }
        public int Checker { get; set; }
        #endregion

        #region ClassTeacher checkbox
        [BindProperty]
        public List<int> ChosenClassIds { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        public int Checker2 { get; set; }
        #endregion

        public void OnGet(string tid)
        {
            Teacher = TeacherService.GetTeacher(tid);
            Subjects = subjectService.GetSubjects();
            Classes = ClassService.GetClasses();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TeacherService.UpdateTeacher(Teacher);

            Teacher = TeacherService.GetTeacher(Teacher.Initials);
            stService.DeleteTeachersSubjects(Teacher.Initials);


            foreach (var cs in ChosenSubjectIds)
            {
                SubjectTeacher = new SubjectTeacher() { Initials = Teacher.Initials, SubjectId = cs };
                stService.CreateSubjectTeacher(SubjectTeacher);
            }
            
            ctService.DeleteTeachersClasses(Teacher.Initials);
            foreach (var ct in ChosenClassIds)
            {
                ClassTeacher = new ClassTeacher() { Initials = Teacher.Initials, ClassId = ct };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            return RedirectToPage("GetTeachers");
        }
    }
}
