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

        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects;

        }
    }
}
