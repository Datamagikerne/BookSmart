using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class CreateClassModel : PageModel
    {
        [BindProperty]
        public Class Class { get; set; }
        public IEnumerable<Class> Classs { get; set; }

        IClassService ClassService;
        public CreateClassModel(IClassService service)
        {
            this.ClassService = service;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Classs = ClassService.GetClasses();
            foreach (var c in Classs)
            {
                if (c.Name == Class.Name)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ClassService.CreateClass(Class);
            return RedirectToPage("GetClasses");
        }
    }
}
