﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Models
{
    public class Category
    {
        //Primary Key
        public int Id { get; set; }

        //Foreign Key simply connects our models together.
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>(); //Property will need to be plural so we know it's a collection.
        //Interfaces are concepts, HashSets are things.
    }
}
