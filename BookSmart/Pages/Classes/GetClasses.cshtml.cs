using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class GetClassesModel : PageModel
    {
        public IEnumerable<Class> Classes { get; set; }



        private IClassService context;
        public GetClassesModel(IClassService service)
        {
            context = service;
        }
        public void OnGet()
        {
            Classes = context.GetClasses();
        }
    }
}
