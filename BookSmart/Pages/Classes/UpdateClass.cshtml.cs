using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;

namespace BookSmart.Pages.Classes
{
    public class UpdateClassModel : PageModel
    {
        IClassService classService;
        IClassTeacherService ctService;
        ITeacherService teacherService;
        

        public UpdateClassModel(IClassService classService, ITeacherService teacherService, IClassTeacherService ctService)
        {
            this.classService = classService;
            this.teacherService = teacherService;
            this.ctService = ctService; 
        }

      
        [BindProperty]
        public Class Class { get; set; }
      
        #region ClassTeacher
        [BindProperty]
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        [BindProperty]
        public List<string> ChosenCtIds { get; set; }
        [BindProperty]
        public ClassTeacher ClassTeacher { get; set; }
        public int Checker { get; set; }
        #endregion

        public void OnGet(int cid)
        {
            Class = classService.GetClass(cid);
            Teachers = teacherService.GetTeachers();
            Classes = classService.GetClasses();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            classService.UpdateClass(Class);
            Class = classService.GetClass(Class.ClassId);

            ctService.DeleteClassesTeachers(Class.ClassId);

            foreach (var cs in ChosenCtIds)
            {
                ClassTeacher = new ClassTeacher() { Initials = cs, ClassId = Class.ClassId };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            return RedirectToPage("GetClasses");
        }
    }
}