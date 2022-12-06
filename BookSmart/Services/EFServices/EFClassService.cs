using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BookSmart.Services.EFServices
{
    public class EFClassService : IClassService
    {
        BookSmartDBContext context;

        public EFClassService(BookSmartDBContext context)
        {
            this.context = context;
        }

        public void CreateClass(Class Class)
        {
            context.Classes.Add(Class);
            context.SaveChanges();
        }

        public Class GetClass(int id)
        {
            return context.Classes.Include(c => c.ClassTeachers).ThenInclude(ct=> ct.InitialsNavigation).AsNoTracking().FirstOrDefault(m => m.ClassId == id);
        }

        public Class GetClassBooks(int id)
        {
            return context.Classes.Include(c => c.BookClasses).ThenInclude(bc => bc.Book).AsNoTracking().FirstOrDefault(m => m.ClassId == id);

        }
        public void UpdateClass(Class Class)
        {
            Class c = GetClass(Class.ClassId);
            context.Entry(c).CurrentValues.SetValues(Class);
            context.SaveChanges();
        }
        public IEnumerable<Class> GetClasses()
        {
            return context.Classes;
        }

        public void DeleteClass(Class Class)
        {
            context.Classes.Remove(Class);
            context.SaveChanges();
        }
    }
}