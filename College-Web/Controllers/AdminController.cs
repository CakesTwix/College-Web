using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using College_Web.Models;

namespace Identity.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<User> userManager;

        public AdminController(UserManager<User> usrMgr)
        {
            userManager = usrMgr;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                User appUser = new User
                {
                    Login = user.Login,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
    }
}