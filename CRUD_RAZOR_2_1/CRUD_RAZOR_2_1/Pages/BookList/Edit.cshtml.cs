using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_RAZOR_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_RAZOR_2_1.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        //bind the property for the Book model and create a method/handler with an object of Book
        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        // on the get we need to retrieve the book based on the id. Located on the Index.cshtml page on the edit button. asp-route-hello which equals item.Id.  The route gets sent here with the route-hello and that is the param such as req.body.  OnGet will grab that data from the database.
        public void OnGet(int hello)
        {
            Book = _db.Books.Find(hello);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = _db.Books.Find(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();
                Message = "Book has been updated successfully!";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}