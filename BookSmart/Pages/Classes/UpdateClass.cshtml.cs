using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Classes
{
    public class UpdateClassModel : PageModel
    {
        IClassService classService;

        public UpdateClassModel(IClassService classService)
        {
            this.classService = classService;
        }

        [BindProperty]
        public Class Class { get; set; }

        public void OnGet(string cid)
        {
            Class = classService.GetClasses(cid);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            classService.UpdateClass(Class);
            return RedirectToPage("GetClasses");
        }
    }
}
