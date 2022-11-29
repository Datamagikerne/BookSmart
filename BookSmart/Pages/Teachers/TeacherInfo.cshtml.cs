using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class TeacherInfoModel : PageModel
    {
        public Teacher Teacher { get; set; }

        ITeacherService context;
        ISubjectTeacherService _subjectTeacherService;
        public SubjectTeacher ST { get; set; } 

        public TeacherInfoModel(ITeacherService service, ISubjectTeacherService subjectTeacherService)
        {
            context = service;
            _subjectTeacherService = subjectTeacherService;
        }
        public void OnGet(string tid, int sid)
        {
            if(sid>0)
            {
                
                ST = _subjectTeacherService.GetSubjectTeachers(tid, sid);
                _subjectTeacherService.DeleteSubjectFromTeacher(ST);
            }
            Teacher = context.GetTeacher(tid);
        }
    }
}
