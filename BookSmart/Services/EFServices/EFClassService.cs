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

        public Class GetClass(string name)
        {
            return context.Classes.Find(name);
        }

        public void UpdateClass(Class Class)
        {
            Class c = GetClass(Class.ClassName);
            context.Entry(c).CurrentValues.SetValues(class);
            context.SaveChanges();
        }

        public IEnumerable<Class> GetClasses()
        {
            return context.Classes;
        }
    }
}

   

