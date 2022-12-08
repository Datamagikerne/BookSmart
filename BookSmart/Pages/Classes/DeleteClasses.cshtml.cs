using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class DeleteClassModel : PageModel
    {
        IClassService classService;

        [BindProperty]
        public Class Class { get; set; }

        public DeleteClassModel(IClassService cService)
        {
            this.classService = cService;
            Class = new Class();
        }

        public void OnGet(int cid)
        {
            Class = classService.GetClass(cid);
        }

        public IActionResult OnPost()
        {
            classService.DeleteClass(Class);
            return RedirectToPage("GetClasses");
        }
    }
}