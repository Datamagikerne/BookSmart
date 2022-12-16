using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Subjects
{
    public class GetSubjectsModel : PageModel
    {
        ISubjectService subjectService;

        public IEnumerable<Subject> Subjects { get; set; }

        public Subject Subject { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetSubjectsModel(ISubjectService sService)
        {
            subjectService = sService;
        }

        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                FilterCriteria= FilterCriteria.ToUpper();
                Subjects = subjectService.GetSubjects().Where(s => s.Name.ToUpper().Contains(FilterCriteria) || 
                (Convert.ToString(s.SubjectId).Contains(FilterCriteria)));
            }
            else
                Subjects = subjectService.GetSubjects();
        }
    }
}