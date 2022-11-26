using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class UpdateTeacherModel : PageModel
    {
        ITeacherService TeacherService;

        public UpdateTeacherModel(ITeacherService TeacherService)
        {
            this.TeacherService = TeacherService;
        }

        [BindProperty]
        public Teacher Teacher { get; set; }

        public void OnGet(string sid)
        {
            Teacher = TeacherService.GetTeacher(sid);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TeacherService.UpdateTeacher(Teacher);
            return RedirectToPage("GetTeachers");
        }
    }
}
