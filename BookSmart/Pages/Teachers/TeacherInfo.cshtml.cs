using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class TeacherInfoModel : PageModel
    {
        public Teacher Teacher { get; set; }
        public Teacher TeacherClasses { get; set; }
        public SubjectTeacher SubjectTeacher { get; set; }

        private ITeacherService context;
        private ISubjectTeacherService subjectTeacherService;

        public TeacherInfoModel(ITeacherService service, ISubjectTeacherService stService)
        {
            context = service;
            subjectTeacherService = stService;
        }

        public void OnGet(string tid, int sid)
        {
            if(sid>0)
            {
                SubjectTeacher = subjectTeacherService;
                subjectTeacherService.DeleteSubjectTeacher(SubjectTeacher);

            }
            Teacher = context.GetTeacher(tid);
            TeacherClasses = context.GetTeachersClasses(tid);
        }

        
    }
}