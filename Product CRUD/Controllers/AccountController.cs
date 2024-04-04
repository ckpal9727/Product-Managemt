using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Product_CRUD.Models;
using Product_CRUD.Repository;
using Microsoft.AspNetCore.Http;

namespace Product_CRUD.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(signUpModel);
                if (result != null)
                {
                    return RedirectToAction("DashBoard", "Account");
                }
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result=await _accountRepository.Login(signInModel);
                if (result!=null)
                {
                    HttpContext.Session.SetString("UserEmail", result.Email);
                   return RedirectToAction("DashBoard", "Account");  
                }
                ModelState.AddModelError("","Login Failed");
            }
            return View(signInModel);
        }

        
        public async Task<IActionResult> Logout()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                HttpContext.Session.Remove("UserEmail");
                return RedirectToAction("DashBoard", "Account");
            }
            
            return View();
        }

        public IActionResult DashBoard()
        {
            if (HttpContext.Session.GetString("UserEmail") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserEmail").ToString();
            }
            
            return View();
        }
             

        }
}
