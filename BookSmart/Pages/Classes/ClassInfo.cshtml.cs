using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.Classes
{
    public class ClassInfoModel : PageModel
    {
        public Class Class { get; set; }
        public Class ClassBooks { get; set; }

        IClassService context;

        public ClassInfoModel(IClassService service)
        {
            context = service;
        }
        public void OnGet(int cid)
        {

            Class = context.GetClass(cid);
            ClassBooks = context.GetClassBooks(cid);
        }
    }
}
