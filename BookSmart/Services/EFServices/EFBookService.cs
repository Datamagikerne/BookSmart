﻿using BookSmart.Models;
using BookSmart.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSmart.Services.EFServices
{
    public class EFBookService : IBookService
    {
        BookSmartDBContext context;

        public EFBookService(BookSmartDBContext context)
        {
            this.context = context; 
        }

        public void CreateBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public Book GetBook(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books.Include(b => b.Subject);
            
        }


    }
}
