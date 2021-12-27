using NTUB.BookStore.site.Models.Core;
using NTUB.BookStore.site.Models.Core.Interfaces;
using NTUB.BookStore.site.Models.Infrastructures.Repositories;
using NTUB.BookStore.site.Models.UseCases;
using NTUB.BookStore.site.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTUB.BookStore.site.Controllers
{
    public class MembersController : Controller
    {
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

	}
}