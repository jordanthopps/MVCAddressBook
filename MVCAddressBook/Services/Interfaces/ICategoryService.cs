using MVCAddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Services.Interfaces
{
    public interface ICategoryService
        /*Watch "What is an interface in C# by IAmTimCorey | Also look at Bob Taber*/
    {
        Task AddContactToCategoryAsync(int categoryId, int contactId);
        //A task runs and does not return anything. When calling AddContact ... it takes its parameters and just runs.
        Task RemoveContactFromCategoryAsync(int categoryId, int contactId);

        Task<ICollection<Category>> GetContactCategoriesAsync(int contactId); //ICollection is loosely coupled

        Task<int> GetContactCountForCategoryAsync(int categoryId);
    }
}
