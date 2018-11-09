using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controller
{
    [Route("api/[Controller]")]
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
            var ticket = _context.TicketItems.FirstOrDefault(t => t.Id == id);

            if(ticket == null)
            {
                return NotFound();  //404
            }
            return new ObjectResult(ticket); //200
        }

        // To add one in the database. Using the FromBody just like node req.body(which gets object in json form to the model into the database. Just like how you set up mongodb in node).
        [HttpPost]
        public IActionResult Create([FromBody]TicketItem ticket)
        {
            if(ticket == null)
            {
                return BadRequest(); // 400
            }
            _context.TicketItems.Add(ticket);
            _context.SaveChanges();
            // createdAtRoute changes the route name of the information you want with "GetTicket" to hide it from the viewers. Then we are adding an id to the database, but here you can also add whatever you want here to the model blue print. Last argu ticket is what you're passing on to the one you just made such as object in json form.
            return CreatedAtRoute("GetTicket", new { id = ticket.Id }, ticket); 
        }

        // get the Id of the one that we want to update from the database and then change it to TicketItem ticket from [FromBody]
        public IActionResult Update(long Id, [FromBody] TicketItem ticket)
        {
            // if ticket doesnt exist or that ticket doenst match the id you asked for
            if (ticket == null || ticket.Id != Id)
            {
                return BadRequest();
            }
            // going to get the ticket. Get the id of the id that yo have passed in.
            var tic = _context.TicketItems.FirstOrDefault(t => t.Id == Id);
            // make sure that ticket is not null but if it is say that its notfound
            if(tic == null)
            {
                return NotFound();
            }
            tic.Concert = ticket.Concert;
            tic.Available = ticket.Available;
            tic.Artist = ticket.Artist;
            _context.TicketItems.Update(tic);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}