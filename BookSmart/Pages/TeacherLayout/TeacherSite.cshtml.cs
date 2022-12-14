using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.TeacherLayout
{
    public class TeacherSiteModel : PageModel
    {
        public Teacher Teacher { get; set; }

        ITeacherService teacherService;
        public string failedLogin { get; set; }

        public TeacherSiteModel(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        public IActionResult OnGet(string LoginDetails)
        {
            if (string.IsNullOrEmpty(LoginDetails))
            {
                return RedirectToPage("TeacherLogin", new { failedLogin = "Incorret Username" });
            }
            int count = 0;
            foreach (var teacher in teacherService.GetTeachers())
            {
                if (LoginDetails.ToLower() == teacher.Initials.ToLower())
                {
                    count++;
                }
            }
            if (count > 0)
            {
                Teacher = teacherService.GetTeacher(LoginDetails);
            }
            else
            {
                return RedirectToPage("TeacherLogin", new { failedLogin = "Incorret Username" });
            }
            return Page();
        }

    }
}