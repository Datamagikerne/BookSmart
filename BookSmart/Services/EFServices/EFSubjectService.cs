using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Services.EFServices
{
    public class EFSubjectService
    {
        BookSmartDBContext context;

        public EFSubjectService(BookSmartDBContext context)
        {
            this.context = context;
        }

        public void DeleteSubject(Subject subject)
        {
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }
    }
}
