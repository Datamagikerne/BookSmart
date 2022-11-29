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

        public Class GetClasses(string cid)
        {
            return context.Classes.Find(cid);
        }

        public void UpdateClass(Class Class)
        {
            Class c = GetClasses(Class.Name);
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

   

