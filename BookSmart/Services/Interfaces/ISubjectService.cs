using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ISubjectService
    {

        Subject GetSubject(int id);
        void UpdateSubject(Subject subject);

        IEnumerable<Subject> GetSubjects();
        void DeleteSubject(Subject subject);

    }
}
