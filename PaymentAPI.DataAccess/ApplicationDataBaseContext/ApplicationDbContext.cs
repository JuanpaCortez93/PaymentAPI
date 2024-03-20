using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.DataAccess.ApplicationDataBaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<PaymentDetails> PaymentDetails { get; set; } 
    }
}
