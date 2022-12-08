using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class TeacherInfoModel : PageModel
    {
        ITeacherService teacherService;
        ISubjectTeacherService subjectTeacherService;
        IClassTeacherService classTeacherService;

        public Teacher Teacher { get; set; }
        public SubjectTeacher SubjectTeacher { get; set; }
        public ClassTeacher ClassTeacher { get; set; }

        public TeacherInfoModel(ITeacherService tService, ISubjectTeacherService stService, IClassTeacherService ctService)
        {
            teacherService = tService;
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
            Teacher = teacherService.GetTeacher(tid);
        }
    }
}