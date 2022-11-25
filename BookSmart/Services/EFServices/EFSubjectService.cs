using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Services.EFServices
{
    public class EFSubjectService : ISubjectService
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
            
        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects;
        }
    }
}
