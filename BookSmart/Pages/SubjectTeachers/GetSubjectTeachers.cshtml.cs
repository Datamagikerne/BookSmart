using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.EFServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Services.Interfaces.STabel;

namespace BookSmart.Pages.SubjectTeachers
{
    public class GetSubjectTeachersModel : PageModel
    {
        

        public string SearchCriteria { get; set; } 
        public IEnumerable<Teacher> Teachers { get; set; }

        public Teacher Teacher { get; set; }    

        ITeacherService context;

        public GetSubjectTeachersModel(ITeacherService service)
        {
            context = service;
        }
        public void OnGet(string sid)
        {
            SearchCriteria = sid;
            Teacher = context.GetTeacher(sid);
        }


    }
}
