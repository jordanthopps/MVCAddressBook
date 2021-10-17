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
        //By adding "AppUser" we tell the database to reference the MVCAddressBook AppUser class, not the default from Microsoft.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        /*A SQL database doesn't speak C# | C# doesn't speak a SQL database.
       Our DbSet is an intermediary method for C# to package information to the database 
        and for the database to package information for C#.*/
        //Equivalent of database table but not the table itself.
        public DbSet<Category> Categories { get; set; }
    }
}
