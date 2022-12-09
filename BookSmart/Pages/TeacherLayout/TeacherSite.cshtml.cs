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

        public void OnGet(string LoginDetails)
        {
            Teacher = teacherService.GetTeacher(LoginDetails);
        }
    }
}