using BookSmart.Models;
using BookSmart.Services.Interfaces;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class ClassInfoModel : PageModel
    {
        public Class Class { get; set; }
        public Class ClassBooks { get; set; }
        public ClassTeacher ClassTeacher { get; set; }
        public BookClass BookClass { get; set; }

        IClassService context;
        IClassTeacherService classTeacherService;
        IBookClassService bookClassService;

        public ClassInfoModel(IClassService service, IClassTeacherService ctService, IBookClassService bookClass)
        {
            context = service;
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
            Class = context.GetClass(cid);
            ClassBooks = context.GetClassBooks(cid);
        }
    }
}
