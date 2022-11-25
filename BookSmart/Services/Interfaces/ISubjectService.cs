using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        void DeleteSubject(Subject subject);
    }
}
