using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Email_Validator.Data;
using Email_Validator.Data.Entities;
using Email_Validator.Data.Context;

namespace Email_Validator.Controllers
{
    public class EmailRecordsController : Controller
    {
        private readonly EmailCheckerContext _context;

        public EmailRecordsController(EmailCheckerContext context)
        {
            _context = context;
        }

        // GET: EmailRecords
        public IActionResult CheckEmail()
        {
              return View();
        }

        // POST: EmailRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckEmail([Bind("Id,Email")] EmailRecord emailRecord)
        {
            if (ModelState.IsValid)
            {
                if (!_context.EmailRecord.Any(e => e.Email == emailRecord.Email))
                {
                    _context.Add(new EmailRecord() { Email = emailRecord.Email, Created = DateTime.Now });
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Thanks");
                }
                ModelState.AddModelError(nameof(emailRecord.Email),"Email already in DB");
                return View(emailRecord);
            }
            ModelState.AddModelError(nameof(emailRecord.Email), "Email not valid");
            return View(emailRecord);
        }
    }
}
