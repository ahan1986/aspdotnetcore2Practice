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
    }
}
