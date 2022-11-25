using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ISubjectService
    {
 
        IEnumerable<Subject> GetSubjects();
        void CreateSubject(Subject Subject);

        Subject GetSubjects(int id);


        Subject GetSubject(int id);
        void UpdateSubject(Subject subject);

        IEnumerable<Subject> GetSubjects();
        void DeleteSubject(Subject subject);


    }
}
