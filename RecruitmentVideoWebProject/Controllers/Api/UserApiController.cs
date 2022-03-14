using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using RecruitmentVideoWebProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace RecruitmentVideoWebProject.Controllers.Api
{
    public class UserApiController : Controller
    {
        Context c = new Context();
        UserManager um = new UserManager(new EfUserDal());

        public IHttpActionResult Get()
        {
            var model = c.Users.Select(s => new UserModel
            {
                UserID = s.UserID,
                UserName = s.UserName,
                UserMail = s.UserMail,
                UserPassword = s.UserPassword,
            }).ToList();
            return Ok(model);
        }

        public IHttpActionResult Post(UserModel model)
        {
            var user = new User
            {
                UserID = model.UserID,
                UserName = model.UserName,
                UserMail = model.UserMail,
                UserPassword = model.UserPassword,
            };
            um.UserAdd(user);
            return Ok();
        }

        public IHttpActionResult Ok(List<UserModel> model)
        {
            return Ok(model);
        }

        public IHttpActionResult Ok()
        {
            return Ok();
        }
    }
}