using BookSmart.Services.EFServices;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BookSmart.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace TestUnitBookSmart
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            BookSmartDBContext test = new BookSmartDBContext(); 
            EFBookService bookService = new EFBookService(test);
            //Act
            IEnumerable<Book> books = bookService.GetBooks();
            //Assert

            foreach(var book in books)
            {

            }
        }
    }
}