using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationFelix.Core;

namespace WebApplicationFelix.Data
{
    public class WebApplicationFelixDbContext : DbContext
    {
        public WebApplicationFelixDbContext(DbContextOptions<WebApplicationFelixDbContext> options) : base(options)
        {

        }

        public DbSet<Shoe> Shoes { get; set; }

    }
}
