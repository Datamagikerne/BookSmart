using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Teachers
{
    public class TeacherInfoModel : PageModel
    {
        public Teacher Teacher { get; set; }

        ITeacherService context;

        public TeacherInfoModel(ITeacherService service)
        {
            context = service;
        }
        public void OnGet(string tid)
        {

            Teacher = context.GetTeacher(tid);
        }
    }
}
