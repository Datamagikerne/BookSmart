using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookSmart.Pages.CoordinatorLayout
{
    public class CoordinatorLoginModel : PageModel
    {
        private ITemaRepository repo;
        public BrugermenuModel(ITemaRepository repository)
        {
            repo = repository;
        }
        public List<Tema> Temaer { get; private set; }
        [BindProperty]
        public Tema tema { get; set; }
        public IActionResult OnGet()
        {
            tema = new Tema();
            Temaer = repo.GetAllTema();
            return Page();
        }
        public void OnPost()
        {

        }
    }
}
