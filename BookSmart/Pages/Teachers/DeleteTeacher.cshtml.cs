using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class DeleteTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher Teacher { get; set; }

        ITeacherService TeacherService;

        public DeleteTeacherModel(ITeacherService service)
        {
            this.TeacherService = service;
            Teacher = new Teacher();
        }

        public void OnGet(string tid)
        {
        }

        public IActionResult OnPost()
        {
            TeacherService.DeleteTeacher(Teacher);
            return RedirectToPage("GetTeachers");
        }
    }
}
