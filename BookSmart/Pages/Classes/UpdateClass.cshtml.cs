using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookSmart.Models;
using BookSmart.Services;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using BookSmart.Services.EFServices;
using System.Security.Cryptography;

namespace BookSmart.Pages.Classes
{
    public class UpdateClassModel : PageModel
    {
        IClassService classService;
        ITeacherService teacherService;
        IClassTeacherService ctService;


        public UpdateClassModel(IClassService classService, ITeacherService teacherService, IClassTeacherService ctService)
        {
            this.classService = classService;
            this.teacherService = teacherService;
            this.ctService = ctService;
        }

        [BindProperty]
        public Class Class { get; set; }

        #region ClassTeacher checkbox
        [BindProperty]
        public List<string> ChosenTeacherIds { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        public int Checker { get; set; }
        #endregion


        public void OnGet(int cid)
        {
            Class = classService.GetClass(cid);
            Teachers = teacherService.GetTeachers();
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

            foreach (var ti in ChosenTeacherIds)
            {
                ClassTeacher = new ClassTeacher() { ClassId = Class.ClassId, Initials = ti };
                ctService.CreateClassTeacher(ClassTeacher);
            }
            
            return RedirectToPage("GetClasses");

        }
        

    }
}
    

