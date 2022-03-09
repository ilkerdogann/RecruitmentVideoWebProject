using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentVideoWebProject.Controllers
{
    public class RegisterController : Controller
    {
        RegisterManager userManager = new RegisterManager(new EfUserDal());

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(User u)
        {
            RegisterValidator registerValidator = new RegisterValidator();
            ValidationResult results = registerValidator.Validate(u);
            if (results.IsValid)
            {
                userManager.UserAdd(u);
                return RedirectToAction("UserRegister", "Register");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}