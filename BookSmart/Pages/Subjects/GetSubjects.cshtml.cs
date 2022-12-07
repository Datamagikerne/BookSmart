using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Subjects
{
    public class GetSubjectsModel : PageModel
    {
        public IEnumerable<Subject> Subjects { get; set; }

        private ISubjectService context;

        public Subject Subject { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetSubjectsModel(ISubjectService service)
        {
            context = service;
        }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                Subjects = context.GetSubjects().Where(s => s.Name.Contains(FilterCriteria) || (Convert.ToString(s.SubjectId).Contains(FilterCriteria)));
            }
            else
                Subjects = context.GetSubjects();
        }
    }
}
