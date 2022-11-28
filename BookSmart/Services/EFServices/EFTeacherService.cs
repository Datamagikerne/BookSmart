using BookSmart.Models;
using BookSmart.Services.Interfaces;


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
            throw new NotImplementedException();
        }

        public Teacher GetTeacher(int id)
        {
            return context.Teachers.Find(id);

        }

        public IEnumerable<Teacher> GetTeachers()
        {
            return context.Teachers;
        }

        public void UpdateTeacher(Teacher Teacher)
        {
            throw new NotImplementedException();
        }
    }
}
