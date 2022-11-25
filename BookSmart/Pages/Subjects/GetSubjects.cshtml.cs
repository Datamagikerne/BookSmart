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
        public GetSubjectsModel(ISubjectService service)
        {
            context = service;
        }
        public void OnGet()
        {
            Subjects = context.GetSubjects();
        }
    }
}
