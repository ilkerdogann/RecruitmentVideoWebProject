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
    public class UserController : Controller
    {

        UserManager um = new UserManager(new EfUserDal());
        UserValidator userValidator = new UserValidator();

        public ActionResult Index()
        {
            var UserValues = um.GetList();
            return View(UserValues);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User p)
        {
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserAdd(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var userValue = um.GetByID(id);
            return View(userValue);
        }

        [HttpPost]
        public ActionResult EditUser(User p)
        {
            ValidationResult results = userValidator.Validate(p);
            if (results.IsValid)
            {
                um.UserUpdate(p);
                return RedirectToAction("Index");
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