using Microsoft.AspNetCore.Mvc;

namespace SchoolPortal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminDashboard()
        {
            return View();
        }
    }
}