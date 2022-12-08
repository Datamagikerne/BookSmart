using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class ClassInfoModel : PageModel
    {
        IClassService classService;
        IClassTeacherService classTeacherService;
        IBookClassService bookClassService;

        public Class Class { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        public BookClass BookClass { get; set; }

        public ClassInfoModel(IClassService cService, IClassTeacherService ctService, IBookClassService bookClass)
        {
            classService = cService;
            classTeacherService = ctService;
            bookClassService = bookClass;
        }

        public void OnGet(int cid, string tid, int bid)
        {
            if(tid != null)
            {
                ClassTeacher = classTeacherService.GetClassTeacher(cid, tid);
                classTeacherService.DeleteClassTeacher(ClassTeacher);
            }
            if(bid > 0)
            {
                BookClass = bookClassService.GetBookClass(bid, cid);
                bookClassService.DeleteBookClass(BookClass);
            }
            Class = classService.GetClass(cid);
        }
    }
}
