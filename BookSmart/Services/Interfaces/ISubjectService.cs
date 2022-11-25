using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        
        void CreateSubject(Subject Subject);

        void UpdateSubject(Subject subject);

        void DeleteSubject(Subject subject);

        Subject GetSubject(int id);
    }
}
