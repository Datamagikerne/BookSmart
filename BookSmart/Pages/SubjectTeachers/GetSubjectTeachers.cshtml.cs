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
        public IEnumerable<SubjectTeacher> SubjectTeachers { get; set; }

        ISubjectTeacherService context;

        public GetSubjectTeachersModel(ISubjectTeacherService service)
        {
            context = service;
        }
        public void OnGet()
        {
            SubjectTeachers = context.GetSubjectTeachers();
        }
    }
}
