using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();//Property will need to be plural so we know it's a collection.

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();//angle brackets <> expect a "type" | For example "football contacts"

    }
}
