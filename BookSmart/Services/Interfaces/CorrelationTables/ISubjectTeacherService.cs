using BookSmart.Models;

namespace BookSmart.Services.Interfaces.CorrelationTables
{
    public interface ISubjectTeacherService
    {
        void CreateSubjectTeacher(SubjectTeacher subjectTeacher);
        void DeleteSubjectTeacher(SubjectTeacher subjectTeacher);
    }
}
