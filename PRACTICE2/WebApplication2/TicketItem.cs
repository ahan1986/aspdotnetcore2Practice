using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class TicketItem
    {
        public object Id { get; internal set; }
        public string Concert { get; set; }
        public string Artist { get; set; }
        public bool Available { get; set; }
    }

    public class TicketContextInTicketItem : DbContext
    {
        public TicketContextInTicketItem(DbContextOptions<TicketContextInTicketItem> options) : base (options)
        {

        }

        public DbSet<TicketItem> TicketItems { get; set; }
    }
}
