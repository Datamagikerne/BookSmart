using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class DeleteTeacherModel : PageModel
    {
        ITeacherService teacherService;

        [BindProperty]
        public Teacher Teacher { get; set; }

        public DeleteTeacherModel(ITeacherService tService)
        {
            this.teacherService = tService;
            Teacher = new Teacher();
        }

        public void OnGet(string tid)
        {
            Teacher = teacherService.GetTeacher(tid);
        }

        public IActionResult OnPost()
        {
            teacherService.DeleteTeacher(Teacher);
            return RedirectToPage("GetTeachers");
        }
    }
}
