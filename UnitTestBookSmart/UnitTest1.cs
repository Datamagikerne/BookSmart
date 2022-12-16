using BookSmart.Models;
using BookSmart.Services.EFServices.CorrelationTables;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace UnitTestBookSmart
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBookProperties()
        {
            Book book = new Book();

            book.Title = "Title";
            Assert.AreEqual(book.Title, "Title");
            book.Author = "Author";
            Assert.AreEqual(book.Author, "Author");
            book.Year = 2001;
            Assert.AreEqual(book.Year, 2001);
        }

        [TestMethod]
        public void TestHasBookList()
        {
            Teacher teacher = new Teacher();    
            Class Class = new Class();
            ClassTeacher classTeacher = new ClassTeacher();

            teacher.Initials = "BOBI";
            Class.ClassId = 1;

            BookSmartDBContext context;
            EFClassTeacherService classTeacherService = new EFClassTeacherService();
            classTeacher.CtId = 1;
            classTeacher.Initials = teacher.Initials;
            classTeacher.ClassId = Class.ClassId;
            classTeacherService.CreateClassTeacher(classTeacher);

            Assert.AreEqual(classTeacher.HasBookList, false);
           
        }

    }
}