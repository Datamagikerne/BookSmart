using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.TeacherLayout
{
    public class TeacherLoginModel : PageModel
    {
        [BindProperty]
        public string LoginDetails { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {
            
        }
    }
}