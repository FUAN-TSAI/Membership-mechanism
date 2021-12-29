using NTUB.BookStore.site.Models.Core;
using NTUB.BookStore.site.Models.Core.Interfaces;
using NTUB.BookStore.site.Models.DTOs;
using NTUB.BookStore.site.Models.Entities;
using NTUB.BookStore.site.Models.Infrastructures.Repositories;
using NTUB.BookStore.site.Models.UseCases;
using NTUB.BookStore.site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NTUB.BookStore.site.Controllers
{
    public class MembersController : Controller
    {
        IMemberRepository repo = new MemberRepository();
        MemberService service;

		public MembersController()
		{
            service = new MemberService();
		}

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Members
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                RegisterCommand command = new RegisterCommand();
                RegisterResponse response = command.Execute(model);

                if (response.IsSuccess)
                {   //建檔成功 redirect to confirm page
                    return View("RegisterConfirm");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.ErrorMessage);
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

		public ActionResult ActiveRegister(int memberId,string confirmCode)
		{
            IMemberRepository repo = new MemberRepository();
            var service = new MemberService(repo);
            service.ActiveRegister(memberId, confirmCode);

            return View();
		}

        public ActionResult Login()
		{
            return View();
		}

        [HttpPost]

		public ActionResult Login(LoginVM model)
		{
            LoginResponse response = service.Login(model.Account, model.Password);
            if (response.IsSuccess)
			{
                var rememberMe = false;
                var returnUrl = ProcessLogin(model.Account, rememberMe, out HttpCookie cookie);
                Response.Cookies.Add(cookie);

                return Redirect(returnUrl);
            }
            ModelState.AddModelError(string.Empty,response.ErrorMessage);
            return this.View(model);
        }

        private string ProcessLogin (string account,bool remrmberMe,out HttpCookie cookie)
		{
            var member = repo.Load(account);
            string roles = String.Empty;

            //建立一張認證票
            FormsAuthenticationTicket ticket = 
                new FormsAuthenticationTicket(
                    1,                          //版本別，沒有特別意思
                    account,
                    DateTime.Now,               //發行日
                    DateTime.Now.AddDays(2),    //到期日
                    remrmberMe,                 //是否續存
                    roles,                      //userdata
                    "/"                         //cookie位置
                    );
            //將它加密
            string value = FormsAuthentication.Encrypt(ticket);

            //存入cookie
            cookie = new HttpCookie(FormsAuthentication.FormsCookieName,value);

            //取得return url
            string url = FormsAuthentication.GetRedirectUrl(account,true);

            return url;
		}

        [Authorize]
        public ActionResult Logout()
		{
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Redirect("/Members/Login");
		}

        [Authorize]
        public ActionResult EditProfile()
        {
            string currentUserAccount = User.Identity.Name;
            MemberEntity entity = repo.Load(currentUserAccount);
            EditProfileVM model = entity.ToEditProfileVM();
            return View(model);
        }

        [Authorize]
        [HttpPost]

        public ActionResult EditProfile(EditProfileVM model)
        {
            string currentUserAccount = User.Identity.Name;

            if (ModelState.IsValid == false)
			{
                return View(model);
            }

            UpdateProfileRequest request = model.ToRequest(currentUserAccount);
			try
			{
                service.UpdateProfile(request);
			}
            catch (Exception ex)
			{
                ModelState.AddModelError(string.Empty,ex.Message);
			}

            if(ModelState.IsValid == true)
			{
				if (string.Compare(User.Identity.Name, model.Account) == 0)
				{
                    //沒有變動Account
                    return RedirectToAction("Index");
				}
				else
				{
                    return RedirectToAction("Logout");
				}
			}
			else
			{
                return View(model);
			}
            
        }

        [Authorize]
        public ActionResult EditPassword()
		{
            return View();
		}

        [Authorize]
        [HttpPost]

        public ActionResult EditPassword(EditPasswordVM model)
        {
            string currentUserAccount = User.Identity.Name;

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            ChangePasswordRequest request = model.ToRequest(currentUserAccount);
            try
            {
                service.ChangePassword(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (ModelState.IsValid == true)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ForgetPassword(ForgetPasswordVM model)
        {
            if(ModelState.IsValid == false)
			{
                return View(model);
            }
			try
			{
                string urlTemplate = Request.Url.Scheme + "://" + Request.Url.Authority + Url.Content("~/") + "Members/ResetPassword?memberid={0}&confirmCode={1}";

                service.RequestResetPassword(model.Account, model.Email,urlTemplate);
                return View("ConfirmForegtPassword");
			}
            catch(Exception ex)
			{
                ModelState.AddModelError(string.Empty,ex.Message);
			}

            return View(model);
        }

		public ActionResult ResetPassword (int memberId,string confirmCode)
		{
            return View();
		}

        [HttpPost]

        public ActionResult ResetPassword(int memberId, string confirmCode,ResetPasswordVM model)
        {
            if(ModelState.IsValid == false)
			{
                return View(model);
			}
			try
			{
                service.ResetPassword(memberId, confirmCode, model.Passward);
			}
            catch (Exception ex)
			{
                ModelState.AddModelError (string.Empty,ex.Message);
			}
            if(ModelState.IsValid == false)
			{
                return View(model);
			}
			else
			{
                return View("ResetPasswordConfirm");
			}
        }
    }
}