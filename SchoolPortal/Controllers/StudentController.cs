using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Data;
using SchoolPortal.Models;

namespace SchoolPortal.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentsController(ApplicationDbContext db) { _db = db; }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var students = await _db.Students.OrderBy(s => s.SerialNumber).ToListAsync();
            return View(students);
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Profile()
        {
            var email = User.Identity?.Name;
            if (string.IsNullOrEmpty(email)) return RedirectToAction("Login", "Account");
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Email == email);
            if (student == null) return RedirectToAction("Index", "Home");
            return View(student);
        }
    }
}