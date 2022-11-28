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
        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; } 
        public IEnumerable<SubjectTeacher> SubjectTeachers { get; set; }

        ISubjectTeacherService context;

        public GetSubjectTeachersModel(ISubjectTeacherService service)
        {
            context = service;
        }
        public void OnGet(string sid)
        {
            SearchCriteria = sid;
            SubjectTeachers = context.GetSubjectTeachers();
        }
    }
}
