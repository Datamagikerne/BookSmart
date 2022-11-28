using BookSmart.Models;


namespace BookSmart.Services.Interfaces.STabel
{
    public interface ISubjectTeacherService
    {
        IEnumerable<SubjectTeacher> GetSubjectTeachers();
        void AddSubjectTeacher(SubjectTeacher SubjectTeacher);
    }
}
