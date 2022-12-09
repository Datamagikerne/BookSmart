using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class GetClassesModel : PageModel
    {
        IClassService classService;

        public IEnumerable<Class> Classes { get; set; }

        public Class Class { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetClassesModel(IClassService cService)
        {
            classService = cService;
        }

        public void OnGet(string tid)
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Classes = classService.GetClasses().Where(c => c.Name.Contains(FilterCriteria) || 
                (c.Education.Contains(FilterCriteria) || (Convert.ToString(c.ClassId).Contains(FilterCriteria))));
            }
            else
                Classes = classService.GetClasses();
        }
    }
}