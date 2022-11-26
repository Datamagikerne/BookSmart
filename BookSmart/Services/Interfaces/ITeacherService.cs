using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface ITeacherService
    {
        
        IEnumerable<Teacher> GetTeachers();

        void CreateTeacher(Teacher teacher);

        void DeleteTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        Teacher GetTeacher(string sid);
        
    }
}
