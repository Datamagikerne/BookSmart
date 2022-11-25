using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        void CreateSubject(Subject Subject);

        Subject GetSubjects(int id);

    }
}
