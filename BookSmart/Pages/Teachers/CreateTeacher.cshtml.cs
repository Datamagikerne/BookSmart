using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class CreateTeacherModel : PageModel
    {
        [BindProperty]
        public Teacher Teacher { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }

        ITeacherService TeacherService;
        public CreateTeacherModel(ITeacherService service)
        {
            this.TeacherService = service;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Teachers = TeacherService.GetTeachers();
            foreach (var t in Teachers)
            {
                if (t.Initials == Teacher.Initials)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TeacherService.CreateTeacher(Teacher);
            return RedirectToPage("GetTeachers");
        }
    }
}

