using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentVideoWebProject.Controllers
{
    public class ManagerController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());

        public ActionResult Index()
        {
            var UserValues = um.GetList();
            return View(UserValues);
        }
    }
}