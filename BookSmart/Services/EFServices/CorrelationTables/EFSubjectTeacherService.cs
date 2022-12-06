using BookSmart.Models;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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
            foreach (var st in context.SubjectTeachers)
            {
                if (initials == st.Initials && subId == st.SubjectId)
                {
                    return st;
                }
            }
            return null;
        }

        public void DeleteTeachersSubjects(string initials)
        {
            foreach (var st in context.SubjectTeachers)
            {
                if (st.Initials == initials)
                {
                    context.SubjectTeachers.Remove(st);
                }
            }
            context.SaveChanges();
        }
    }
}