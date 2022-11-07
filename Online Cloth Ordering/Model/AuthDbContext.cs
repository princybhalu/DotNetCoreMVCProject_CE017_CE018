using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Cloth_Ordering.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Cloth_Ordering.Model
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        {

        }

        public DbSet<Products> Products { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Sessions> Sessions { get; set; }


    }
}
