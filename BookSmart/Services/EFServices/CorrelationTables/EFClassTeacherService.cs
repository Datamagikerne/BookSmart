using BookSmart.Models;
using BookSmart.Services.Interfaces.CorrelationTables;

namespace BookSmart.Services.EFServices.CorrelationTables
{
    public class EFClassTeacherService : IClassTeacherService
    {
        BookSmartDBContext context;
        public EFClassTeacherService(BookSmartDBContext context)
        {
            this.context = context;
        }
        public void CreateClassTeacher(ClassTeacher classTeacher)
        {
            context.ClassTeachers.Add(classTeacher);
            context.SaveChanges();
        }
        public void DeleteClassTeacher(ClassTeacher classTeacher)
        {
            context.ClassTeachers.Remove(classTeacher);
            context.SaveChanges();
        }
    }
}
