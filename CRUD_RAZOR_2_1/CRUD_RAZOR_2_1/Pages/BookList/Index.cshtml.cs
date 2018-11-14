using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_RAZOR_2_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_RAZOR_2_1.Pages.BookList
{
    public class IndexModel : PageModel
    {
        // to pass data from the page model to the razor page in a view in controller.  You can write property here. So in JS terms, define the variable here and then set the variable in the OnGet() method/handler.  This will now be able to send information out  to the respecitve razor page by typing @Model.someData like how you defined in here.
        public string someData { get; set; }

        //to use the Book Model in our database, we need to acess our database by having the object of ApplicationDbContext here and defining a variable e.g. someData. dependency injection for CRUD_RAZOR_2_1.Model. Set this variable private so that no other classes can use it.
        private readonly ApplicationDbContext _db;

        // this has to be the same name (Message) as the one in create.cshtml.cs. TempData stores anyinformation throughout the controllers so that if you use the same name, you can access that same TempData variable anywhere however, it only can be accessed again once and after that it will be erased.
        [TempData]
        public string Message { get; set; }

        // to retrieve the complete list of data, we create a list of books so we need IEnumerable
        public IEnumerable<Book> Books { get; set; }
        //create constructor. This is a boiler plate so that the local db can be used.
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
         
        

        // this model can only pass data to the View which will be the index.cshtml.cs in the BookList folder in the pages folder
        public async Task OnGet() // this is a handler. This will be executed when a GET request comes in 
        {
            someData = "This is the first property";


            Books = await _db.Books.ToListAsync();
        }
    }
}