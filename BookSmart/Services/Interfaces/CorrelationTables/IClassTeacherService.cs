using BookSmart.Models;

namespace BookSmart.Services.Interfaces.CorrelationTables
{
    public interface IClassTeacherService
    {
        void CreateClassTeacher(ClassTeacher classTeacher);

        void DeleteClassTeacher(ClassTeacher classTeacher);
        
        void DeleteTeachersClasses(string initials);

        void DeleteClassesTeachers(int id);

        void ChangeBooklistStatus(int CID, string TID);

        ClassTeacher GetClassTeacher(int classId, string initials);
    }
}
