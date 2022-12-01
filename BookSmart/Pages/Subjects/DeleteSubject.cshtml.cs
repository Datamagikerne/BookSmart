using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Subjects
{
    public class DeleteSubjectModel : PageModel
    {
        [BindProperty]
        public Subject Subject { get; set; }

        ISubjectService SubjectService;

        public DeleteSubjectModel(ISubjectService service)
        {
            this.SubjectService = service;
            Subject = new Subject();
        }
        public void OnGet(int sid)
        {
            Subject = SubjectService.GetSubject(sid);
        }
        public IActionResult OnPost()
        {
            SubjectService.DeleteSubject(Subject);
            return RedirectToPage("GetSubjects");
        }
    }
}
