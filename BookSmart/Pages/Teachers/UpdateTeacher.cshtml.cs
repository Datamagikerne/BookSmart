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

        public UpdateTeacherModel(ITeacherService TeacherService, ISubjectTeacherService stService, ISubjectService subjectService)
        {
            this.TeacherService = TeacherService;
            this.stService = stService;
            this.subjectService = subjectService;

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

        public void OnGet(string tid)
        {
            Teacher = TeacherService.GetTeacher(tid);
            Subjects = subjectService.GetSubjects();
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
            return RedirectToPage("GetTeachers");
        }
    }
}
