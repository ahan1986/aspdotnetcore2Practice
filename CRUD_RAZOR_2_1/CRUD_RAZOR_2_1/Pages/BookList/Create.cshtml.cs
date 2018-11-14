using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_RAZOR_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_RAZOR_2_1.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        // creating one book at a time
        // **[BindProperty] ** if you don't want to add Book Book to a parameter to OnGet or OnPost methods.
        public Book Book { get; set; }

        public void OnGet()
        {

        }
        // ** if you don't add the parameters (Book Book), you can also add [BindProperty] to public Book Book { get; set; }. This will bind Book to everything in this class
        public async Task<IActionResult> OnPost(Book Book)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            //you're grabbing Book defined in params and adding it to the database. Then you have to always SaveChangesAsync() this is saving the changes to the database. So you have to manually add it and then tell it to save it.
            _db.Books.Add(Book);
            await _db.SaveChangesAsync();
            // Redirect to the Index section method. To Index page because thats where we will be displaying all the books.
            return RedirectToPage("Index");

        }
    }
}