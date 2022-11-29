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
        public IEnumerable<Teacher> GetTeachers()
        {
            //return context.Teachers.Include(b => b.Subjectid);
            return context.Teachers;
        }

        public void CreateTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            context.Teachers.Remove(teacher);
            context.SaveChanges();
        }

        public Teacher GetTeacher(string sid)
        {
            var teacher = context.Teachers.Include(t => t.SubjectTeachers).ThenInclude(st => st.Subject).AsNoTracking().FirstOrDefault(m => m.Initials == sid);
            return teacher;
        }

        

        public void UpdateTeacher(Teacher teacher)
        {
            Teacher t = GetTeacher(teacher.Initials);
            context.Entry(t).CurrentValues.SetValues(teacher);
            context.SaveChanges();
        }
    }
}
