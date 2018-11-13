using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_RAZOR_2_1.Model
{
    //inherit/Extend DbContext from EntityFrameworkCore
    public class ApplicationDbContext : DbContext
    {
        //need a constructor. type ctor and then tab twice for short cut to create constructor
        // add in params the DbContextOptions from entityframworkcore and then the applicationdbContext in the params as the model
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Set Book.cs model and call it Books and then apply a getter and setter
        // after DbSet, you need to push these changes to the database so you will now need Migrations
        // go to Tools > Nuget Package Manager > Package Manager Console
        //type: add-migration *meaningfulName* and then a migrations folder and files will be generated.  at package manager console type update-database
        public DbSet<Book> Books { get; set; }
    }
}
