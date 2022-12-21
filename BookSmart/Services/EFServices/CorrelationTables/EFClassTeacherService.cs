using BookSmart.Models;
using BookSmart.Services.Interfaces.CorrelationTables;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BookSmart.Services.EFServices.CorrelationTables
{
    public class EFClassTeacherService : IClassTeacherService
    {
        BookSmartDBContext context;

        public EFClassTeacherService(BookSmartDBContext context)
        {
            this.context = context;
        }

        public void CreateClassTeacher(ClassTeacher classTeacher)
        {
            classTeacher.HasBookList = false;
            context.ClassTeachers.Add(classTeacher);
            context.SaveChanges();
        }

        public void DeleteClassTeacher(ClassTeacher classTeacher)
        {
            if (classTeacher != null)
            {
                context.ClassTeachers.Remove(classTeacher);
                context.SaveChanges();
            }
        }

        //public void DeleteTeachersClasses(string initials)
        //{
        //    foreach(var ct in context.ClassTeachers)
        //    {
        //        if(ct.Initials == initials)
        //        {
        //            context.ClassTeachers.Remove(ct);
        //        }
        //    }
        //    context.SaveChanges();
        //}

        public void DeleteClassesTeachers(int id)
        {
            foreach (var ct in context.ClassTeachers)
            {
                if (ct.ClassId == id)
                {
                    context.ClassTeachers.Remove(ct);
                }
            }
            context.SaveChanges();
        }

        public ClassTeacher GetClassTeacher(int classId, string initials)
        {
            return context.ClassTeachers.Where(ct => ct.ClassId == classId && ct.Initials == initials).AsNoTracking().FirstOrDefault();
        }

        public void ChangeBooklistStatus(int CID, string TID)
        {
            //the method GetClassTeacher has AsNoTracking in it, so it cant be used to update,
            //so we have to get it from DBcontect manually
            ClassTeacher ct = context.ClassTeachers
                .Where(ct => ct.ClassId == CID && ct.Initials == TID).FirstOrDefault();
            ct.HasBookList = true;
            context.SaveChanges();
        }

        public void UpdateTeachersClasses(List<int> chosenClassIds, Teacher teacher)
        {
            List<ClassTeacher> classesToDelete = new List<ClassTeacher>();

            //go through classes that teacher had before and compare then to the new checked classes
            foreach (var ct in teacher.ClassTeachers)
            {
                int count = chosenClassIds.Count;

                foreach (var ctid in chosenClassIds)
                {
                    if (ct.ClassId != ctid)
                    {
                        count--;
                    }
                }
                //class has gone through list of new checked classes, if it doesn't exist count
                // is 0, and it needs to be deleted, so add to list of classes to delete list
                if (count == 0)
                {
                    classesToDelete.Add(ct);
                }
                //every class teacher has before update needs to be removed from list to 
                //update sp it doesn't get added again
                chosenClassIds.Remove((int)ct.ClassId);

            }
            foreach (var ct in classesToDelete)
            {
                //get entity to delete from database end delete it
                ClassTeacher classToRemove= GetClassTeacher((int)ct.ClassId, teacher.Initials);
                DeleteClassTeacher(classToRemove);
            }
            foreach (var ct in chosenClassIds)
            {
                //all we have left in chosenClassIds, are the ids that doesnt exist in Teacher before
                //update, they can now be created and added to teacher
                ClassTeacher classToAdd= new ClassTeacher() { Initials = teacher.Initials, ClassId = ct };
                CreateClassTeacher(classToAdd);
            }
        }
    }
}