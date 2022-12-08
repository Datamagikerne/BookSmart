using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Subjects
{
    public class CreateSubjectModel : PageModel
    {
        ISubjectService subjectService;

        [BindProperty]
        public Subject Subject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public CreateSubjectModel(ISubjectService sService)
        {
            this.subjectService = sService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Subjects = subjectService.GetSubjects();
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
            subjectService.CreateSubject(Subject);
            return RedirectToPage("GetSubjects");
        }
    }
}