using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.TeacherLayout
{
    public class TeacherSiteModel : PageModel
    {
        public Teacher Teacher { get; set; }

        ITeacherService teacherService;
        IBookClassService bookClassService;

        public TeacherSiteModel(ITeacherService teacherService, IBookClassService bookClassService)
        {
            this.teacherService = teacherService;
            this.bookClassService = bookClassService;
        }
        public IEnumerable<BookClass> BookClasses { get; set; }
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
                return RedirectToPage("TeacherLogin", new {errorMessage = "Wrong Password"});
            }
            BookClasses = bookClassService.GetBookClasses();
            return Page();
        }
    }
}