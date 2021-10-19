using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCAddressBook.Data;
using MVCAddressBook.Models;
using MVCAddressBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Controllers
{
    [Authorize]
    public class EmailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly UserManager<AppUser> _userManager;

        public EmailsController(
            ApplicationDbContext context, 
            IEmailSender emailSender, 
            UserManager<AppUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);

            var model = new EmailTemplateViewModel
            {
                CategoryList = new SelectList(_context.Categories.Where(c => c.UserId == userId), "Id", "Name")
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int categoryId, EmailTemplateViewModel model)
        {
            var category = _context.Categories.Include(c => c.Contacts).FirstOrDefault(c => c.Id == categoryId);

            foreach (var contact in category.Contacts)
            {
                await _emailSender.SendEmailAsync(contact.Email, model.Subject, model.Message);
            }

            return RedirectToAction(nameof(Index), "Contacts");
        }
    }
}
