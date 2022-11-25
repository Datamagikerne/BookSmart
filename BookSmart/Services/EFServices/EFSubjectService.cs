using BookSmart.Models;

namespace BookSmart.Services.EFServices
{
    public class EFSubjectService
    {
        BookSmartDBContext context;

        public EFSubjectService(BookSmartDBContext context)
        {
            this.context = context;
        }
    }
}
