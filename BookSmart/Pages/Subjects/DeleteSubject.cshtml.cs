using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Subjects
{
    public class DeleteSubjectModel : PageModel
    {
        ISubjectService subjectService;

        [BindProperty]
        public Subject Subject { get; set; }

        public DeleteSubjectModel(ISubjectService sService)
        {
            this.subjectService = sService;
            Subject = new Subject();
        }

        public void OnGet(int sid)
        {
            Subject = subjectService.GetSubject(sid);
        }

        public IActionResult OnPost()
        {
            subjectService.DeleteSubject(Subject);
            return RedirectToPage("GetSubjects");
        }
    }
}
