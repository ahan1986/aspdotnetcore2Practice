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
        [HttpGet("{id}")] // we are going to pull the "id" from the url. like req.param. 
       public IActionResult GetById(long id)
        {
            // going to find the ticket id that we have searched for or passed in. Need FirstOrDefault because if we dont' find anything it will default ticket that is null and doesnt contain anything.
            var ticket = _context.TicketItems.FirstOrDefault(t => t.id == id);

            if(ticket == null)
            {
                return NotFound();  //404
            }
            return new ObjectResult(ticket); //200
        }

        // To add one in the database
        public IActionResult Create(TicketItem ticket)
        {
            if(ticket == null)
            {
                return BadRequest(); // 400
            }
            _context.TicketItems.Add(ticket);
            _context.SaveChanges();
            // createdAtRoute changes the route name of the information you want with "GetTicket" to hide it from the viewers. Then we are adding an id to the database, but here you can also add whatever you want here to the model blue print
            return CreatedAtRoute("GetTicket", new { id = ticket.Id }); 
        }
    }
}