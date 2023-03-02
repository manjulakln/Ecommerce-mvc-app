using Ecommercemvcapp.Data;
using Ecommercemvcapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ecommercemvcapp.Data.ViewModels;
using Ecommercemvcapp.Data.Static;

namespace Ecommercemvcapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanager,
            AppDbContext context)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _context = context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid) 
                return View(loginVM);
            var user = await _usermanager.FindByEmailAsync(loginVM.Emailaddress);
            if(user != null)
            {
                var passwordcheck = await _usermanager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordcheck)
                {
                    var result = await _signinmanager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong credentials";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials";
            return View(loginVM);   
        }
        public ActionResult Register()
        {
            return View(new RegisterVM());
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            if(!ModelState.IsValid) { return View(registerVM); }
            var user = await _usermanager.FindByEmailAsync(registerVM.Emailaddress);
            if(user != null)
            {
                TempData["Error"] = "User is already exist";
                return View(registerVM);
            }
            var newuser = new ApplicationUser()
            {
                Email = registerVM.Emailaddress,
                FullName = registerVM.FullName,
                UserName = registerVM.Emailaddress
            };
            var newuserresponse = await _usermanager.CreateAsync(newuser,registerVM.Password);
            if (newuserresponse.Succeeded)
            {
                await _usermanager.AddToRoleAsync(newuser, UserRole.User);
                return View("RegisterCompleted");
            }
            else
                return View(registerVM);
               

        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index","Movies");
        }
    }
}
