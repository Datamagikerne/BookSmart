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
        public ClassTeacher ClassTeacher { get; set; }

        private ITeacherService context;
        private ISubjectTeacherService subjectTeacherService;
        private IClassTeacherService classTeacherService;

        public TeacherInfoModel(ITeacherService service, ISubjectTeacherService stService, IClassTeacherService ctService)
        {
            context = service;
            subjectTeacherService = stService;
            classTeacherService = ctService;
        }

        public void OnGet(string tid, int sid, int cid)
        {
            if(sid>0)
            {
                SubjectTeacher = subjectTeacherService.GetSubectTeacher(sid, tid);
                subjectTeacherService.DeleteSubjectTeacher(SubjectTeacher);

            }
            if(cid>0) 
            {
                ClassTeacher = classTeacherService.GetClassTeacher(cid, tid);
                classTeacherService.DeleteClassTeacher(ClassTeacher);
            }
            Teacher = context.GetTeacher(tid);
            TeacherClasses = context.GetTeachersClasses(tid);
        }

        
    }
}