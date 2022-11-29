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

        public Teacher GetTeacher(string tid)
        {
            var teacher = context.Teachers.Include(t => t.SubjectTeachers).ThenInclude(st => st.Subject).AsNoTracking().FirstOrDefault(m => m.Initials == tid);
            return teacher;
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers;
        }

        public void UpdateTeacher(Teacher Teacher)
        {
            Teacher b = GetTeacher(Teacher.Initials);
            context.Entry(b).CurrentValues.SetValues(Teacher);
            context.SaveChanges();
        }
    }
}
