using Microsoft.AspNetCore.Http;
using MVCAddressBook.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Models
{
    public class Contact //every class we add is a column in a database
    {
        //Primary key (me)
        public int Id { get; set; } //This is a database property. Unless specified, the db will use this prop as a key.
       
        //Foreign key (someone else)
        public string UserId { get; set; } //Prop naming convention: first leters of words are capitalized.
        //Foreign keys must exist.

        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public States State { get; set; } //why store a state as an integer? We are going to use an "enum" which is stored in the db as an integer.

        public int ZipCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime Created { get; set; }

        [NotMapped] //this is called a data annotation. This says "do not put the prop underneath in the db."
        public IFormFile ImageFile { get; set; } //a. represents a file on a computer

        public byte[] ImageData { get; set; } //b. this is a byte array. Represents when a file has been split apart and converted to the bytes that instruct a computer to recreate it.
        public string ImageType { get; set; } //c. 

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } } //we do not need to store the user's fullname as it's a combo of first and last which we have. We remove set.
                                                                             //Instead, we create a property that queries the database for the first and last name together.
                                                                             //$"" is string interpolation that pulls this together.

        public virtual AppUser User{ get; set; }//this is a navigational property. Not stored in the db. This is how we tell our db that every collection of contacts maps to one user.
                                                //a non-nullable data types must have a value. Example: int and DataTime.

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>(); //angle brackets <> expect a "type" | For example "football contacts"
            //12:07
    }

}
