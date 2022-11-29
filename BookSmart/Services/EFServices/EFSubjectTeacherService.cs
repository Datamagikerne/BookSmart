using BookSmart.Models;
using BookSmart.Services;
using BookSmart.Services.Interfaces;

namespace BookSmart.Services.EFServices
{
    public class EFSubjectTeacherService : ISubjectTeacherService
    {
        BookSmartDBContext context;

        public EFSubjectTeacherService(BookSmartDBContext context)
        {
            this.context = context;
        }
        public void DeleteSubjectFromTeacher(SubjectTeacher ST)
        {
            context.SubjectTeachers.Remove(ST);
            context.SaveChanges();
        }

        public SubjectTeacher GetSubjectTeachers(string tid, int sid)
        {
            foreach (var st in context.SubjectTeachers)
            {
                if (tid == st.Initials && sid == st.SubjectId)
                {
                    return st;
                }
            }
            return null;
        }
    }
}
