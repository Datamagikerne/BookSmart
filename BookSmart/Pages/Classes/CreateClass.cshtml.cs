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
        public IEnumerable<Class> Classes { get; set; }

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
            Classes = ClassService.GetClasses();
            foreach (var c in Classes)
            {
                if (c.ClassId == Class.ClassId)
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
