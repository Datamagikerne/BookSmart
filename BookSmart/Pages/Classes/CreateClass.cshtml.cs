using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class CreateClassModel : PageModel
    {
        IClassService classService;
        
        
        IClassTeacherService ctService;
        ITeacherService teacherService;

        [BindProperty]
        public Class Class { get; set; }
        public IEnumerable<Class> Classes { get; set; }

        

        #region Teacher Checkbox
        public IEnumerable<Teacher> Teachers { get; set; }
        [BindProperty]
        public List<string> ChosenTeacherIds { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        #endregion

        public CreateClassModel(IClassService cService, IClassTeacherService ctServ, ITeacherService teacherServ)
        {
            this.classService = cService;
            ctService = ctServ;
            teacherService = teacherServ;
        }
        public void OnGet()
        {
            Teachers = teacherService.GetTeachers(); 
        }
        public IActionResult OnPost()
        {
            Classes = classService.GetClasses();
            foreach (var c in Classes)
            {
                if (c.ClassId == Class.ClassId)
                {
                    return Page();
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            classService.CreateClass(Class);
            Class = classService.GetClass(Class.ClassId);

            foreach (var ct in ChosenTeacherIds)
            {
                ClassTeacher = new ClassTeacher() { ClassId = Class.ClassId, Initials = ct };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            return RedirectToPage("GetClasses");
        }
    }
}