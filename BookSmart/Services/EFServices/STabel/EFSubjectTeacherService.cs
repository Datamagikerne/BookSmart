using BookSmart.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSmart.Services.EFServices.STabel
{
    public class EFSubjectTeacherService
    {
        BookSmartDBContext context;
        public EFSubjectTeacherService(BookSmartDBContext service)
        {
            context = service;
        }
        public IEnumerable<SubjectTeacher> GetSubjectTeachers()
        {
            return context.SubjectTeachers.Include(s => s.InitialsNavigation).Include(c => c.Subject);
        }
        public void AddSubjectTeacher(SubjectTeacher SubjectTeacher)
        {
            context.SubjectTeachers.Add(SubjectTeacher);
            context.SaveChanges();
        }
    }
}
