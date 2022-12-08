using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.TeacherLayout
{
    public class TeacherLoginModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Initials { get; set; }

        public void OnGet()
        {
        }

        public void OnPost() 
        {
            
        }
    }
}
