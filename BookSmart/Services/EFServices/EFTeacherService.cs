using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Services.EFServices
{
    public class EFTeacherService : ITeacherService
    {
        BookSmartDBContext context;

        public EFTeacherService(BookSmartDBContext context)
        {
            this.context = context;
        }

        public void CreateTeacher(Teacher Teacher)
        {
            context.Teachers.Add(Teacher);
            context.SaveChanges();
        }

        public void DeleteTeacher(Teacher Teacher)
        {
            context.Teachers.Remove(Teacher);
            context.SaveChanges();
        }

        public Teacher GetTeacher(string id)
        {
            var teacher = context.Teachers
                .Include(t => t.ClassTeachers).ThenInclude(ct => ct.Class)
                .Include(t => t.SubjectTeachers).ThenInclude(st => st.Subject).AsNoTracking().FirstOrDefault(m => m.Initials == id);
            return teacher;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers;
        }

        public void UpdateTeacher(Teacher teacher)
        {
            foreach (var t in context.Teachers)
            {
                if (t.Initials.Contains(teacher.Initials))
                {
                    t.Initials = teacher.Initials;
                    t.Name = teacher.Name;
                    t.Mail = teacher.Mail;
                }
            }
            context.SaveChanges();
        }
    }
}