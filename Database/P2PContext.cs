using Microsoft.EntityFrameworkCore;
using P2P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2P.Database
{
    public class P2PContext : DbContext
    {
        public P2PContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
