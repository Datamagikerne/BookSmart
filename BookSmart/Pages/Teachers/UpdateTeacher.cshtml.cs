using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class UpdateTeacherModel : PageModel
    {
        private ITeacherService TeacherService;

        [BindProperty]
        public Teacher Teacher { get; set; }

        public UpdateTeacherModel(ITeacherService service)
        {
            TeacherService = service;
        }

        public void OnGet(string tid)
        {
            Teacher = TeacherService.GetTeacher(tid);   
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            TeacherService.UpdateTeacher(Teacher);
            return RedirectToPage("Getteachers");
        }
    }
}
