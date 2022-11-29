using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<Teacher> GetTeachers();

        void CreateTeacher(Teacher Teacher);

        void UpdateTeacher(Teacher Teacher);

        void DeleteTeacher(Teacher Teacher);

        Teacher GetTeacher(string tid);
        void DeleteSubjectFromTeacher(SubjectTeacher ST);
        SubjectTeacher GetSubjectTeachers(string tid, int sid);

    }
}
