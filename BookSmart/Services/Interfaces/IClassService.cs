using BookSmart.Models;

namespace BookSmart.Services.Interfaces
{
    public interface IClassService
    {
        IEnumerable<Class> GetClasses();

        void CreateClass(Class Class);

        void UpdateClass(Class Class);

        void DeleteClass(Class Class);

        Class GetClass(string name);
    }
}
