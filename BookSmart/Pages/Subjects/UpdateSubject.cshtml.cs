using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services;
using BookSmart.Services.Interfaces;

namespace BookSmart.Pages.Subjects
{
    public class UpdateSubjectModel : PageModel
    {
        ISubjectService subjectService;

        public UpdateSubjectModel(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [BindProperty]
        public Subject Subject { get; set; }
        
        public void OnGet(int sid)
        {
            Subject = subjectService.GetSubject(sid);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            subjectService.UpdateSubject(Subject);
            return RedirectToPage("GetSubjects");
        }
    }
}
