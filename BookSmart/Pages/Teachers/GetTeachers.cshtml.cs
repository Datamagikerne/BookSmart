using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;

namespace BookSmart.Pages.Teachers
{
    public class GetTeachersModel : PageModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }

        private ITeacherService context;

        public GetTeachersModel(ITeacherService service)
        {
            context = service;
        }

        public void OnGet()
        {
            Teachers = context.GetTeachers();
        }
    }
}
