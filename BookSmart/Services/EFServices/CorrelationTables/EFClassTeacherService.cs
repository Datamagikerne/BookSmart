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

        public void DeleteTeachersClasses(string initials)
        {
            foreach(var ct in context.ClassTeachers)
            {
                if(ct.Initials == initials)
                {
                    context.ClassTeachers.Remove(ct);
                }
            }
            context.SaveChanges();
        }
        public void DeleteTeachersClass(int id)
        {
            foreach (var ct in context.ClassTeachers)
            {
                if (ct.ClassId == id)
                {
                    context.ClassTeachers.Remove(ct);
                }
            }
            context.SaveChanges();
        }

        public void DeleteClassesTeachers(int id)
        {
            foreach (var ct in context.ClassTeachers)
            {
                if (ct.ClassId == id)
                {
                    context.ClassTeachers.Remove(ct);
                }
            }
            context.SaveChanges();
        }

        public ClassTeacher GetClassTeacher(int classId, string initials)
        {
            foreach (var ct in context.ClassTeachers)
            {
                if (initials == ct.Initials && classId == ct.ClassId)
                {
                    return ct;
                }
            }
            return null;
        }
    }
}