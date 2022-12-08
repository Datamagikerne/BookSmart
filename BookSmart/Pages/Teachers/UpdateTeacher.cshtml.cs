using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class UpdateTeacherModel : PageModel
    {
        ITeacherService teacherService;
        ISubjectTeacherService stService;
        ISubjectService subjectService;
        IClassTeacherService ctService;
        IClassService classService;

        public UpdateTeacherModel(ITeacherService teacherService, ISubjectTeacherService stService, 
                                  ISubjectService subjectService, IClassTeacherService ctService,  IClassService classService)
        {
            this.teacherService = teacherService;
            this.stService = stService;
            this.subjectService = subjectService;
            this.ctService = ctService;
            this.classService = classService;
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
        #endregion

        public void OnGet(string tid)
        {
            Teacher = teacherService.GetTeacher(tid);
            Subjects = subjectService.GetSubjects();
            Classes = classService.GetClasses();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            teacherService.UpdateTeacher(Teacher);
            Teacher = teacherService.GetTeacher(Teacher.Initials);
            
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
