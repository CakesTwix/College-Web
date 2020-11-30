using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using College_Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> signInManager;

        public AccountController(UserManager<UserApp> usrMgr, SignInManager<UserApp> signinMgr)
        {
            userManager = usrMgr;
            signInManager = signinMgr;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ViewResult Create() => View();

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                UserApp appUser = await userManager.FindByNameAsync(login.Name);
                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    if (result.Succeeded)
                        return Redirect(login.ReturnUrl ?? "/");
                }
                ModelState.AddModelError(nameof(login.Name), "Login Failed: Invalid Name or password");
            }
            return View(login);
        }


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

                var result = await userManager.CreateAsync(appUser, user.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    //Set role "User" as default role
                    result = await userManager.AddToRoleAsync(appUser, "Student");
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(appUser, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(user);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}