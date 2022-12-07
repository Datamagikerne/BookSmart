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

        public Class Class { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetClassesModel(IClassService service)
        {
            context = service;
        }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Classes = context.GetClasses().Where(c => c.Name.Contains(FilterCriteria) || (c.Education.Contains(FilterCriteria)));
            }
            else
                Classes = context.GetClasses();
        }
    }
}

