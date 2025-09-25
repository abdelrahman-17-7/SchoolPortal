using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolPortal.Models;

namespace SchoolPortal.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;

        public BaseController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected string GetCurrentUserFullName()
        {
            var user = _userManager.GetUserAsync(User).Result;
            return user?.FullName ?? "Unknown User";  // 👈 safe call
        }
    }
}