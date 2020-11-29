using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using College_Web.Models;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserApp> userManager;

        public AccountController(UserManager<UserApp> usrMgr)
        {
            userManager = usrMgr;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create(UserApp user)
        {
            if (ModelState.IsValid)
            {
                UserApp appUser = new UserApp
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
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