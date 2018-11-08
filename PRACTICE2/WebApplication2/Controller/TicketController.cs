using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        //going to need the database context or the information
        private TicketContextInTicketItem _context;

        public TicketController(TicketContextInTicketItem context)
        {
            _context = context;

            if(_context.TicketItems.Count() == 0)
            {
                _context.TicketItems.Add(new TicketItem { Concert = "Beyonce" });
                _context.SaveChanges();
            }
        }
        // list of ticket items or collection we can iterate through
        [HttpGet]
        public IEnumerable<TicketItem> GetAll()
        {
            return _context.TicketItems.ToList();
        }

        //to get a specific id
       
    }
}