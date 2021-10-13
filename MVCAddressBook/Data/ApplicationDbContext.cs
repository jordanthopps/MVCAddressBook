using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCAddressBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

//This ApplicationDbContext.cs class interacts with the database. 

namespace MVCAddressBook.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
        //By adding "AppUser" we tell the database to reference the MVCAddressBook AppUser class, not the default.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
