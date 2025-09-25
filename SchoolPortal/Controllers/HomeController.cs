using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Data;
using SchoolPortal.Models;

namespace SchoolPortal.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
            : base(userManager)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            // Admin sees dashboard cards
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            // Students see their personal dashboard
            var email = User.Identity?.Name;
            var student = _context.Students.FirstOrDefault(s => s.Email == email);
            return View(student);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}