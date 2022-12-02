using BookSmart.Models;
using BookSmart.Services.Interfaces.CorrelationTables;

namespace BookSmart.Services.EFServices.CorrelationTables
{
    public class EFSubjectTeacherService : ISubjectTeacherService
    {
        BookSmartDBContext context;
        public EFSubjectTeacherService(BookSmartDBContext context)
        {
            this.context = context;
        }
        public void CreateSubjectTeacher(SubjectTeacher subjectTeacher)
        {
            context.SubjectTeachers.Add(subjectTeacher);
            context.SaveChanges();
        }
        public void DeleteSubjectTeacher(SubjectTeacher subjectTeacher)
        {
            context.SubjectTeachers.Remove(subjectTeacher);
            context.SaveChanges();
        }
        public SubjectTeacher GetSubectTeacher(int subId, string initials)
        {

        }
    }
}
