using Email_Validator.Data.Context;
using Email_Validator.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Email_Validator.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmailCheckerContext _context;
        private readonly IConfiguration _config;

        public HomeController(EmailCheckerContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEmailRecords()
        {
            var mockEmails = _config.GetSection("EmailMockData").Get<List<string>>();
            foreach (var email in mockEmails)
            {
                if (_context.EmailRecord.Any(e => e.Email == email))
                {
                    continue;
                }
                _context.Add(new EmailRecord { Email = email, Created = DateTime.Now });
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
