using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class DeleteClassModel : PageModel
    {
        [BindProperty]
        public Class Class { get; set; }

        IClassService ClassService;

        public DeleteClassModel(IClassService service)
        {
            this.ClassService = service;
            Class = new Class();
        }
        public void OnGet(int cid)
        {
            Class = ClassService.GetClass(cid);
        }
        public IActionResult OnPost()
        {
            ClassService.DeleteClass(Class);
            return RedirectToPage("GetClasses");
        }
    }
}
