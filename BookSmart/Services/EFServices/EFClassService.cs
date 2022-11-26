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
            throw new NotImplementedException();
        }

        public void DeleteClass(Class Class)
        {
            throw new NotImplementedException();
        }

        public Class GetClass(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> GetClasses()
        {
            return context.Classes;
        }

        public void UpdateClass(Class Class)
        {
            throw new NotImplementedException();
        }
    }
}
