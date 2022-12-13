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

        public TeacherSiteModel(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        public IActionResult OnGet(string LoginDetails)
        {
            

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
                return RedirectToPage("TeacherLogin");
            }
            return Page();
        }
    }
}