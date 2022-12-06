using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Subjects
{
    public class CreateSubjectModel : PageModel
    {

        [BindProperty]
        public Subject Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        ISubjectService SubjectService;

        public CreateSubjectModel(ISubjectService service)
        {
            this.SubjectService = service;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Subjects = SubjectService.GetSubjects();
            foreach (var b in Subjects)
            {
                if (b.SubjectId == Subject.SubjectId)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SubjectService.CreateSubject(Subject);
            return RedirectToPage("GetSubjects");
        }
    }
}

