using Microsoft.AspNetCore.Http;
using MVCAddressBook.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Models
{
    public class Contact //Step 1.
                         //Every property we add is a column in the database.
    {
        //Primary key (me)
        public int Id { get; set; } //This is a database property. Unless specified, the db will use this prop as a key.
       
        //Foreign key (someone else)
        public string UserId { get; set; } //Prop naming convention: first leters of words are capitalized.
                                           //Foreign keys must exist for multi-tenant projects.

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string  FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        /*DateTime is a non-nullable datatype that we need to access null values since we don't know if
         a user will enter it. Append a ? to the end to make it nullable*/

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        public States State { get; set; } //why store a state as an integer? We are going to use an "enum" which is stored in the db as an integer.

        [Required]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public DateTime Created { get; set; }

        [NotMapped] //this is called a data annotation. This says "do not put the prop underneath in the db."
        [DataType(DataType.Upload)]
        [Display(Name = "Contact Image")]
        public IFormFile ImageFile { get; set; } 
        /*a. When an image is uploaded, the image itself is not stored in the database.
        IFormFile parses an x64 string that the computer understands and this is what
        is stored in the db. This is built-in security that defends against malicious uploads.*/


        public byte[] ImageData { get; set; } //b. this is a byte array. Represents when a file has been split apart and converted to the bytes that instruct a computer to recreate it.
        public string ImageType { get; set; } //c. ImageType represents the file extension of the image (jpeg, PNG, etc.)

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } } //we do not need to store the user's fullname as a sesparate column in the db as it's a combo of FirstName and LastName which we have.
                                                                             //Instead, we "get" a property that returns the database values of the first and last name concatenated.
                                                                             //$"" is string interpolation that pulls this together.

        public virtual AppUser User{ get; set; }//this is a navigational property. Not stored in the db. This is how we tell our db that every contact maps to one and only one user.
        //John's contacts aren't Jane's contacts which aren't Sam's contacts.

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>(); //angle brackets <> expect a "type" | For example "football contacts"
        //This property is unique to each user because of how we build the Category model, not because of the property itself.    
        //An empty ICollection exists. And as long as it exists, we can add stuff to it. new HashSet<Category>() says when a new contact is created, it's going to need something to go into the Categories prop.
        //The reason why categories and collections are represented as collections of one another is because both can exist without the either.
        //Make the property names of collections plural. I.e., Categories
    }

}
