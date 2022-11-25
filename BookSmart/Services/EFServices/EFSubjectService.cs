﻿using BookSmart.Models;
using BookSmart.Services.Interfaces;
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

        public Subject GetSubject(int id)
        {
            return context.Subjects.Find(id);
        }

        public void UpdateSubject(Subject subject)
        {
            Subject s = GetSubject(subject.SubjectId);
            context.Entry(s).CurrentValues.SetValues(subject);
            context.SaveChanges();
        }
    }
}
