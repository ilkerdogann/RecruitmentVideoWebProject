using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RecruitmentVideoWebProject.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User p)
        {
            var userInfo = c.Users.FirstOrDefault(x => x.UserName == p.UserName && x.UserPassword == p.UserPassword);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.UserName, false);
                Session["UserName"] = userInfo.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }

        [HttpGet]
        public ActionResult ManagerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(Manager p)
        {
            var managerInfo = c.Managers.FirstOrDefault(x => x.ManagerName == p.ManagerName && x.ManagerPassword == p.ManagerPassword);
            if (managerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(managerInfo.ManagerName, false);
                Session["ManagerName"] = managerInfo.ManagerName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("ManagerLogin");
            }
        }

        [HttpGet]
        public ActionResult WorkerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WorkerLogin(Worker p)
        {
            var workerInfo = c.Workers.FirstOrDefault(x => x.WorkerName == p.WorkerName && x.WorkerPassword == p.WorkerPassword);
            if (workerInfo != null)
            {
                FormsAuthentication.SetAuthCookie(workerInfo.WorkerName, false);
                Session["WorkerName"] = workerInfo.WorkerName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("WorkerLogin");
            }
        }
    }
}