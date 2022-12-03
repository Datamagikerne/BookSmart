using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Services.EFServices
{
    public class EFSubjectService : ISubjectService
    {
        BookSmartDBContext context;

        public EFSubjectService(BookSmartDBContext context)
        {
            this.context = context;
        }

        public void CreateSubject(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public Subject GetSubject(int id)
        {
            return context.Subjects.Find(id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects;
        }

        public void UpdateSubject(Subject subject)
        {
            Subject s = GetSubject(subject.SubjectId);
            context.Entry(s).CurrentValues.SetValues(subject);
            context.SaveChanges();
        }
       

        public void DeleteSubject(Subject subject)
        {
            context.Subjects.Remove(subject);
            context.SaveChanges();
        }
    }
}
