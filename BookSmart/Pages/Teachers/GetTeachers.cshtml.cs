using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;

namespace BookSmart.Pages.Teachers
{
    public class GetTeachersModel : PageModel
    {
        ITeacherService teacherService;

        public IEnumerable<Teacher> Teachers { get; set; }
        
        public Teacher Teacher { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        public GetTeachersModel(ITeacherService tService)
        {
            teacherService = tService;
        }
        public void OnGet()
        {
            if (!String.IsNullOrEmpty(FilterCriteria))
            {
                FilterCriteria = FilterCriteria.ToUpper();
                Teachers = teacherService.GetTeachers().Where(t => t.Name.ToUpper().Contains(FilterCriteria) || 
                (t.Initials.ToUpper().Contains(FilterCriteria) || (t.Mail.ToUpper().Contains(FilterCriteria))));
            }
            else
                Teachers = teacherService.GetTeachers();
        }
    }
}
