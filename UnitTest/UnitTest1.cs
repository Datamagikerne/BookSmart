using BookSmart.Services.EFServices;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookSmart.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestGetBook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BookSmartDBContext>().UseInMemoryDatabase(databaseName: "BookSmartDB").Options;
            BookSmartDBContext bookSmartDB1 = new BookSmartDBContext(options,null);
            EFBookService bookService = new EFBookService(bookSmartDB1);

            var subject = bookSmartDB1.Subjects.Add(new Subject { Name = "Math" });


           var book = bookSmartDB1.Books.Add(new Book { SubjectId = subject.Entity.SubjectId, Author = "Anders" });

            bookSmartDB1.SaveChanges();
            
            //Act
            
            
            Book book1 = bookService.GetBook(book.Entity.BookId);
            //Assert

            Assert.IsNotNull(book1);
            Assert.AreEqual(book1.Author, "Anders");
        }
    }
}