using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Models;
using mvcprojectfinal.VM;
using System.Security.Claims;

namespace mvcprojectfinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppliacationUser> userManager;
        private readonly SignInManager<AppliacationUser> signInManager;

        public AccountController
            (UserManager<AppliacationUser> _userManager, SignInManager<AppliacationUser> signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = signInManager;
        }
        //regieter
        //open view "link
        public IActionResult Registeration()
        {
            return View();
        }
        //save data dabe Request ==>db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registeration(RegistrationVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                AppliacationUser userModel = new AppliacationUser();
                userModel.Email = newUserVM.UserEmail;
                userModel.UserName = newUserVM.Name;
                userModel.Gender = newUserVM.Gender;
                userModel.age = newUserVM.age;
                userModel.PasswordHash = newUserVM.Password;

                IdentityResult result =
                    await userManager.CreateAsync(userModel, newUserVM.Password);//object insert db

                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(userModel, "User");//insert row UserRole

                    List<Claim> addClaim = new List<Claim>();
                    addClaim.Add(new Claim("Intake", "43"));
                    await signInManager.SignInWithClaimsAsync(userModel, false, addClaim);
                    //await  signInManager.SignInAsync(userModel, false); //session cookie register
                    return RedirectToAction("Index", "MainPage");
                }
                else
                {
                    //some issue ==>send user view
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(newUserVM);
        }

        public async Task<IActionResult> signOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
            //return Content("Signed out");
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM userVmReq)//username,password,remeberme 
        {
            if (ModelState.IsValid)
            {
                //check valid  account "found in db"
                AppliacationUser userModel =
                    await userManager.FindByNameAsync(userVmReq.Username);
                if (userModel != null)
                {
                   
                    //cookie
                    Microsoft.AspNetCore.Identity.SignInResult rr =
                        await signInManager.PasswordSignInAsync(userModel, userVmReq.Password, userVmReq.rememberMe, false);
                   
                    //check cookie
                    if (rr.Succeeded)
                        return RedirectToAction("Index", "MainPage");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Data !!");
                }
            }
            return View(userVmReq);
        }
    }
}
