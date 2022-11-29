using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ISubjectTeacherService
    {
        void DeleteSubjectFromTeacher(SubjectTeacher ST);
        SubjectTeacher GetSubjectTeachers(string tid, int sid);
    }
}
