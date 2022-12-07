using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;

namespace BookSmart.Pages.Teachers
{
    public class GetTeachersModel : PageModel
    {
        public IEnumerable<Teacher> Teachers { get; set; }

        private ITeacherService context;
        public Teacher Teacher { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetTeachersModel(ITeacherService service)
        {
            context = service;
        }
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Teachers = context.GetTeachers().Where(t => t.Name.Contains(FilterCriteria) || (t.Initials.Contains(FilterCriteria) || (t.Mail.Contains(FilterCriteria))));
            }
            else
                Teachers = context.GetTeachers();
        }
    }
}
