using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Net;

namespace Forum.Controllers{
    public class AccountController : Controller {
        private ForumUserManager UserManager {
            get {
                return HttpContext.GetOwinContext().GetUserManager<ForumUserManager>();
            }
        }

        /**
         * Register() - is an implamentation of user registration on the forum.
         * */

        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model) {
            if (ModelState.IsValid) {
                ApplicationUser user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded) {
                    //Generating token to confirm registration
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //creating a link for the confirmation
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //Sending an email
                    await UserManager.SendEmailAsync(user.Id, "Подтверждение электронноый почты", "Для завершения регистрации перейдите по ссылке: <a href=\"" + callbackUrl + "\">завершить регистрацию</a>");
                    return View("DisplayEmail");
                }
            }
            return View(model);
        }

        /**
         * Login() - is an implementation of user Authentication on the forum.
         * */
        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl) {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl) {
            if (ModelState.IsValid) {
                ApplicationUser user = await UserManager.FindAsync(model.Username, model.Password);
                if (user == null) {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                } else {
                    if (user.EmailConfirmed) {
                        ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties {
                            IsPersistent = true
                        }, claim);
                        if (String.IsNullOrEmpty(returnUrl)) {
                            return RedirectToAction("Index", "Home");
                        }
                        return Redirect(returnUrl);
                    } else {
                        ModelState.AddModelError("", "Не подтвержден email.");
                    }
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult LogOff() {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code) {
            if (userId == null || code == null) {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        public ForumUserManager GetUserManager() {
            return UserManager;
        }
    }
}