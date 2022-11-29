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
        public SubjectTeacher ST { get; set; } 

        public TeacherInfoModel(ITeacherService service)
        {
            context = service;
        }
        public void OnGet(string tid, int sid)
        {
            if(sid>0)
            {
                
                ST = context.GetTeachersSubject(tid, sid);
                context.DeleteSubjectFromTeacher(ST);
            }
            Teacher = context.GetTeacher(tid);
        }
    }
}
